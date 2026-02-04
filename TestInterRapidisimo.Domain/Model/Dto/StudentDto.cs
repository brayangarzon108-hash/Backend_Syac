using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("Students", Schema = "dbo")]
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public int ProgramId { get; set; }
        public ProgramDto Program { get; set; } = null!;
        public ICollection<StudentSubjectDto> StudentSubjects { get; set; } = new List<StudentSubjectDto>();
    }
}
