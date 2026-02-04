
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("StudentSubjects", Schema = "dbo")]
    public class StudentSubjectDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentSubjectId { get; set; }
        public int StudentId { get; set; }
        public StudentDto Student { get; set; } = null!;
        public int SubjectId { get; set; }
        public SubjectDto Subject { get; set; } = null!;
    }
}
