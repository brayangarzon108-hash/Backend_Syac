using TCI.API.Domain.Class.ActivosO.Activos;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IStudentRepository
    {

        Task<string> CreateAsync(CreateStudentResponse dto);
        Task<string> UpdateAsync(int studentId, UpdateStudentResponse dto);
        Task<string> DeleteAsync(int studentId);
        Task<HeadStudentListResponse> GetAllAsync(int page, int pageSize, string search);
        Task<List<ProgramDto>> GetAllProgramationAsync();
    }
}
