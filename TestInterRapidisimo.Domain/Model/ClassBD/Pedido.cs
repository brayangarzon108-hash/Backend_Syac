using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Backend.Domain.Model.Response.General.Enumeration;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("OrdenPedido", Schema = "dbo")]
    public class Pedido : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenPedidoId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public DateTime FechaRegistro { get; set; }
        public EstadoPedido Estado { get; set; }

        public string DireccionEntrega { get; set; } = null!;
        public PrioridadPedido Prioridad { get; set; }

        public decimal ValorTotal { get; set; }

        public ICollection<OrdenPedidoDetalle> Detalles { get; set; } = new List<OrdenPedidoDetalle>();
    }
}
