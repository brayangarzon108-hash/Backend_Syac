using TCI.API.Domain.Class.ActivosO.Activos;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IStudentSubjectRepository
    {
        Task<List<SubjectResponse>> GetAllSubjectAsync();
        /// <summary>
        /// Método que registra la inscripción de un estudiante a una materia
        /// </summary>
        /// <returns></returns>
        Task<string> EnrollSubjectAsync(int studentId, int subjectId);
        Task<List<ListStudentSubjectResponse>> GetStudentClassmatesAsync(int studentId);
        Task<string> DeleteAsync(int studentSubjectId);
    }
}
