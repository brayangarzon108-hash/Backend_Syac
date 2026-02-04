using TCI.API.Domain.Response.Sistema;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IStudentCore
    {

        /// <summary>
        ///  Guardar Alumno
        /// </summary>
        /// <param name="info"></param>
        /// <returns> List<ReportesClass> </returns>
        Task<GeneralResponse> CreateAsync(CreateStudentResponse info);

        /// <summary>
        /// Actualizar Alumno
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        Task<GeneralResponse> UpdateAsync(int studentId, UpdateStudentResponse dto);

        /// <summary>
        /// Actualizar Alumno
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        Task<GeneralResponse> DeleteAsync(int studentId);

        /// <summary>
        ///  Consulto Alumnos
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        Task<GeneralResponse> GetAllAsync(int page, int pageSize, string search);

        /// <summary>
        ///  Consulto Programas
        /// </summary>
        /// <returns> List<ReportesClass> </returns>
        Task<GeneralResponse> GetAllProgramationAsync();
    }
}
