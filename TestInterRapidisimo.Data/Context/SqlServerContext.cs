using Microsoft.EntityFrameworkCore;
using TCI.API.Domain.Class.ActivosO.Activos;

namespace Console.Migration.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options) { }
        public DbSet<Pedido> ordenPedidos { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<OrdenPedidoDetalle> ordenPedidoDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdenPedidoDetalle>()
                .HasIndex(ss => new { ss.DetalleId})
                .IsUnique();

            modelBuilder.Entity<Producto>(
                b =>
                {
                    b.HasKey(e => new { e.ProductoId });
                });

            modelBuilder.Entity<Pedido>(
               b =>
               {
                   b.HasKey(e => new { e.OrdenPedidoId });
               });


            modelBuilder.Entity<Cliente>(
               b =>
               {
                   b.HasKey(e => new { e.ClienteId });
               });

            modelBuilder.Entity<OrdenPedidoDetalle>(
               b =>
               {
                   b.HasKey(e => new { e.DetalleId });
               });
        }    
    }
}
