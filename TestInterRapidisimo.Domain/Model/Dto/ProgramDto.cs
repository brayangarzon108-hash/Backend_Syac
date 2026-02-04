using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("Programs", Schema = "dbo")]
    public class ProgramDto
    {
        public ProgramDto ()
        {
        }

        [Column("ProgramId")]
        [Key]
        [Required]
        public int ProgramId { get; set; }
        [Column("Name")]
        public string Name { get; set; } = null!;
        [Column("TotalCredits")]
        public int TotalCredits { get; set; }
        public ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
        [Column("UpdateAt")]
        public DateTime UpdateAt { get; set; }        
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }       
    }
}
