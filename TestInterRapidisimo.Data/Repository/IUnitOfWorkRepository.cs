using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IUnitOfWorkRepository
    {
        IPedidoRepository Pedidos { get; }
        Task<int> SaveChangesAsync();
    }
}
