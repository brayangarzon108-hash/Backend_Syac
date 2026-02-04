using TCI.API.Domain.Class.ActivosO.Activos;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IPedidoRepository : IDataRepository<Pedido>
    {
        /// <summary>
        /// Método que cosnulta la inscripción de un estudiante a una materia
        /// </summary>
        /// <returns></returns>
        Task<List<Pedido>> GetPedidosConDetalleAsync();
    }
}
