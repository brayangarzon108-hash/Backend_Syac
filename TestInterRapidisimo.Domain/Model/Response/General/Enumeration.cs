namespace Backend.Domain.Model.Response.General
{
    public class Enumeration
    {
        public enum EstadoPedido
        {
            Registrado = 1,
            Confirmado = 2,
            Anulado = 3
        }

        public enum PrioridadPedido
        {
            Baja = 1,
            Media = 2,
            Alta = 3
        }
    }
}
