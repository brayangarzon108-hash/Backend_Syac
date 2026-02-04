using AutoMapper;
using Backend.Domain.Model.Response.General;
using TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato;
using TCI.API.Domain.Class.ActivosO.Activos;
using TestInterRapidisimo.Domain.Model.Response;
using static Backend.Domain.Model.Response.General.Enumeration;
namespace API.DataAccess.DataAccess
{
    // Se crea metodo de la tabla Cliente
    public class PedidosCore : IPedidosCore
    {

        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public PedidosCore(IUnitOfWorkRepository unitOfWork,
        IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Método que crea pedidos
        /// </summary>
        /// <returns></returns>
        public async Task<int> CrearPedidoAsync(PedidoCreateDto dto)
        {
            if (dto.Detalles == null || !dto.Detalles.Any())
                throw new Exception("El pedido debe tener al menos un producto");

            var pedido = _mapper.Map<Pedido>(dto);

            pedido.FechaRegistro = DateTime.Now;

            pedido.ValorTotal = pedido.Detalles.Sum(d =>
            {
                d.ValorParcial = d.Cantidad * d.ValorUnitario;
                return d.ValorParcial;
            });

            pedido.Prioridad = CalcularPrioridad(pedido.ValorTotal);
            pedido.Estado = Enumeration.EstadoPedido.Registrado;

            await _unitOfWork.Pedidos.AddAsync(pedido);
            await _unitOfWork.SaveChangesAsync();

            return pedido.OrdenPedidoId;
        }

        /// <summary>
        /// Método que confirma pedidos
        /// </summary>
        /// <returns></returns>
        public async Task ConfirmarPedidoAsync(int id)
        {
            var pedido = await _unitOfWork.Pedidos.GetByIdAsync(id);

            if (pedido == null)
                throw new Exception("Pedido no encontrado");

            if (pedido.Estado != Enumeration.EstadoPedido.Registrado)
                throw new Exception("Solo pedidos registrados pueden confirmarse");

            pedido.Estado = Enumeration.EstadoPedido.Confirmado;
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método que anula pedidos
        /// </summary>
        /// <returns></returns>
        public async Task AnularPedidoAsync(int id)
        {
            var pedido = await _unitOfWork.Pedidos.GetByIdAsync(id);

            if (pedido == null)
                throw new Exception("Pedido no encontrado");

            pedido.Estado = Enumeration.EstadoPedido.Anulado;
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método que obtiene pedidos
        /// </summary>
        /// <returns></returns>
        public async Task<List<PedidoDto>> ObtenerPedidosAsync()
        {
            var pedidos = await _unitOfWork.Pedidos.GetPedidosConDetalleAsync();
            return _mapper.Map<List<PedidoDto>>(pedidos);
        }

        /// <summary>
        /// Método que calcula prioridades
        /// </summary>
        /// <returns></returns>
        private PrioridadPedido CalcularPrioridad(decimal total)
        {
            if (total <= 500) return Enumeration.PrioridadPedido.Baja;
            if (total <= 1000) return Enumeration.PrioridadPedido.Media;
            return Enumeration.PrioridadPedido.Alta;
        }
    }
}
