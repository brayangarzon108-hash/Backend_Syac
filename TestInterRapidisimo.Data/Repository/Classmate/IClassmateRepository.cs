using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IClassmateRepository
    {


        /// <summary>
        /// Método que consulta los estudiante que comparten materias con un estudiante.
        /// </summary>
        /// <returns></returns>
        Task<HeadStudentListResponse> GetClassmatesAsync(int studentId, int page, int pageSize, int subjectId, string nameStudent = "");
    }
}
