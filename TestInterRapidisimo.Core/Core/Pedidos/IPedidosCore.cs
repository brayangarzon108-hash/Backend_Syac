using TCI.API.Domain.Class.ActivosO.Activos;
using TestInterRapidisimo.Domain.Model.Response;

namespace API.DataAccess.DataAccess
{
    public interface IPedidosCore
    {

        Task<int> CrearPedidoAsync(PedidoCreateDto dto);
        Task ConfirmarPedidoAsync(int id);
        Task AnularPedidoAsync(int id);
        Task<List<PedidoDto>> ObtenerPedidosAsync();
    }
}
