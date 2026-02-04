using AutoMapper;
using TCI.API.Domain.Class.ActivosO.Activos;
using TestInterRapidisimo.Domain.Model.Response;

namespace Backend.Domain.Model.AutoMapper
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoDto>()
                .ForMember(d => d.ClienteId,
                    o => o.MapFrom(s => s.Cliente.Identificacion));

            CreateMap<OrdenPedidoDetalle, DetallePedidoDto>()
                .ForMember(d => d.Producto,
                    o => o.MapFrom(s => s.Producto.ProductoId));

            CreateMap<PedidoCreateDto, Pedido>();
            CreateMap<DetallePedidoCreateDto, OrdenPedidoDetalle>();
        }
    }
}
