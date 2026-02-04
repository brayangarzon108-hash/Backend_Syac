
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("OrdenPedidoDetalle", Schema = "dbo")]
    public class OrdenPedidoDetalle : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetalleId { get; set; }

        public int OrdenPedidoId { get; set; }
        public Pedido OrdenPedido { get; set; } = null!;

        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;

        public decimal ValorUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorParcial { get; set; }
    }
}
