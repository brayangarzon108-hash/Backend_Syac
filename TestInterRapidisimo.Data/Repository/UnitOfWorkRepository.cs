using Console.Migration.Context;
using TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato;

namespace StudentRegistration.API.Services;

public class UnitOfWorkRepository : IUnitOfWorkRepository
{
    private readonly SqlServerContext _context;

    public IPedidoRepository Pedidos { get; }

    public UnitOfWorkRepository(SqlServerContext context)
    {
        _context = context;
        Pedidos = new PedidoRepository(context);
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
