using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("Professors", Schema = "dbo")]
    public class ProfessorDto
    {
        public int ProfessorId { get; set; }
        public string FullName { get; set; } = null!;

        public ICollection<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
    }
}
