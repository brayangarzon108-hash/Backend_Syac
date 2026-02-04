namespace TestInterRapidisimo.Domain.Model.Response
{
    public class PedidoDto
    {
        public int OrdenPedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string DireccionEntrega { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
        public decimal ValorTotal { get; set; }
        public List<DetallePedidoDto> Detalles { get; set; }
    }
}
