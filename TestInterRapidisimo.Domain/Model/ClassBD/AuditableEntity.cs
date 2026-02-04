namespace TCI.API.Domain.Class.ActivosO.Activos
{
    public abstract class AuditableEntity
    {
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioCreacion { get; set; } = "master";

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
        public string? UsuarioModificacion { get; set; } = "master";

        public bool Activo { get; set; } = true;
    }
}
