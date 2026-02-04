using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("Producto", Schema = "dbo")]
    public class Producto : AuditableEntity
    {
        public Producto ()
        {
        }

        public int ProductoId { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal ValorUnitario { get; set; }

        public ICollection<OrdenPedidoDetalle> Detalles { get; set; } = new List<OrdenPedidoDetalle>();
    }
}
