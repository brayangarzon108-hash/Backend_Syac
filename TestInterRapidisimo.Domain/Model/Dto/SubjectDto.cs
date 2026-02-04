
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("Subjects", Schema = "dbo")]
    public class SubjectDto
    {
        public int SubjectId { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; } = 3;
        public int ProfessorId { get; set; }
        public ProfessorDto Professor { get; set; } = null!;
        public ICollection<StudentSubjectDto> StudentSubjects { get; set; } = new List<StudentSubjectDto>();
    }
}
