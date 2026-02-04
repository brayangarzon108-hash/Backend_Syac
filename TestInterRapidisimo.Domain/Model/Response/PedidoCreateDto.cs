namespace TestInterRapidisimo.Domain.Model.Response
{
    public class PedidoCreateDto
    {
        public int ClienteId { get; set; }
        public string DireccionEntrega { get; set; }
        public List<DetallePedidoCreateDto> Detalles { get; set; }
    }

    public class DetallePedidoCreateDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
