using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente : AuditableEntity
    {
        public int ClienteId { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public ICollection<Pedido> Ordenes { get; set; } = new List<Pedido>();
    }
}
