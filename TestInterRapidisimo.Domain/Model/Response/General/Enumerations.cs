namespace TCI.API.Domain.Response.Sistema
{
    public static class ValueString
    {
        public static string Exito = "Exito";
    }
    public class Enumerations
    {
        public enum enumTypeMessageResponse
        {
            Success = 200,
            Error = 500,
            BadRequest = 400,
            NotFound = 404
        }
    }
}
