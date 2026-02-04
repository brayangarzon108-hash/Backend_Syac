namespace TestInterRapidisimo.Domain.Model.Response
{
    public class DetallePedidoDto
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorParcial { get; set; }
    }
}
