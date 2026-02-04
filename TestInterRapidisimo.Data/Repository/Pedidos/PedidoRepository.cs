using Console.Migration.Context;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.API.Services;
using TCI.API.Domain.Class.ActivosO.Activos;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class PedidoRepository : DataRepository<Pedido>, IPedidoRepository
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly SqlServerContext _context;

        public PedidoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que cosnulta la inscripción de un estudiante a una materia
        /// </summary>
        /// <returns></returns>
        public async Task<List<Pedido>> GetPedidosConDetalleAsync()
        {
            try
            {
                return await _context.ordenPedidos
                    .Include(p => p.Cliente)
                    .Include(p => p.Detalles)
                        .ThenInclude(d => d.Producto)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
