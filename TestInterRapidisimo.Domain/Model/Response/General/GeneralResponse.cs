namespace TCI.API.Domain.Response.Sistema
{
    public class GeneralResponse
    {

        public GeneralResponse()
        {

        }
        public int Status { get; set; } = 0;
        public dynamic? Data { get; set; }
        public string Message { get; set; } = "Proceso Realizado exitosamente";
    };
}
