using Console.Migration.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.PortableExecutable;
using TCI.API.Domain.Class.ActivosO.Activos;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class StudentRepository : IStudentRepository
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly SqlServerContext _context;

        public StudentRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAsync(CreateStudentResponse dto)
        {
            // Email único
            if (await _context.Students.AnyAsync(s => s.Email == dto.Email))
                return "El email ya está registrado.";

            // Programa válido
            if (!await _context.Programs.AnyAsync(p => p.ProgramId == dto.ProgramId))
                return "El programa no existe.";

            var student = new StudentDto
            {
                FullName = dto.FullName,
                Email = dto.Email,
                ProgramId = dto.ProgramId
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return "Exito";
        }

        public async Task<string> UpdateAsync(int studentId, UpdateStudentResponse dto)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                return "Estudiante no encontrado.";

            // Programa válido
            if (!await _context.Programs.AnyAsync(p => p.ProgramId == dto.ProgramId))
                return "El programa no existe.";

            student.FullName = dto.FullName;
            student.ProgramId = dto.ProgramId;

            await _context.SaveChangesAsync();
            return "Exito";
        }

        public async Task<string> DeleteAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                return "Estudiante no encontrado.";

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return "Exito";
        }

        public async Task<HeadStudentListResponse> GetAllAsync(int page, int pageSize, string search)
        {
            var header = new HeadStudentListResponse();

            var data = _context.Students
                .Include(s => s.Program).AsAsyncEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(s => s.FullName.Contains(search));
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
                    FullName = s.FullName,
                    Email = s.Email,
                    ProgramId = s.ProgramId,
                    ProgramName = s.Program.Name
                })
                .ToListAsync();
                return header;
            }

            header.CountRegister = infocount;
            header.InfomationProcess = await data.Select(s => new StudentListResponse
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                ProgramId = s.ProgramId,
                ProgramName = s.Program.Name
            })
            .ToListAsync();
            return header;
        }

        public async Task<List<ProgramDto>> GetAllProgramationAsync()
        {
            var data = await _context.Programs.ToListAsync();
            return data;
        }
    }
}
