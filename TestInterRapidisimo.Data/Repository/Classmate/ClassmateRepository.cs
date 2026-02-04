using Console.Migration.Context;
using Microsoft.EntityFrameworkCore;
using TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato;
using TestInterRapidisimo.Domain.Model.Response;

namespace StudentRegistration.API.Services;

public class ClassmateRepository : IClassmateRepository
{
    private readonly SqlServerContext _context;

    public ClassmateRepository(SqlServerContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método que consulta los estudiante que comparten materias con un estudiante.
    /// </summary>
    /// <returns></returns>
    public async Task<HeadStudentListResponse> GetClassmatesAsync(int studentId, int page, int pageSize, int subjectId, string nameStudent = "")
    {
        // Validar estudiante
        var exists = await _context.Students.AnyAsync(s => s.StudentId == studentId);
        if (!exists)
            throw new Exception("El estudiante no existe.");

        var header = new HeadStudentListResponse();

        var data = _context.StudentSubjects.Where(x => x.StudentId != studentId && x.SubjectId == subjectId)
            .Include(s => s.Student).Include(s => s.Student.Program).Include(s => s.Subject).AsAsyncEnumerable();

        if (!string.IsNullOrEmpty(nameStudent))
        {
            data = data.Where(s => s.Student.FullName.Contains(nameStudent));
        }

        var infocount = await data.CountAsync();
        // Pagination
        if ((page == 0 && pageSize == 0) || page * pageSize >= infocount)
        {
            //Console.WriteLine("Número de página fuera de rango.");
        }
        else
        {
            // Pagination
            var formListresult = data.Skip(page * pageSize).Take(pageSize);

            header.CountRegister = infocount;
            header.InfomationProcess = await formListresult.Select(s => new StudentListResponse
            {
                StudentId = s.StudentId,
                FullName = s.Student.FullName,
                Email = s.Student.Email,
                ProgramId = s.Student.ProgramId,
                ProgramName = s.Student.Program.Name
            })
            .ToListAsync();
            return header;
        }

        header.CountRegister = infocount;
        header.InfomationProcess = await data.Select(s => new StudentListResponse
        {
            StudentId = s.StudentId,
            FullName = s.Student.FullName,
            Email = s.Student.Email,
            ProgramId = s.Student.ProgramId,
            ProgramName = s.Student.Program.Name
        })
        .ToListAsync();
        return header;
    }
}
