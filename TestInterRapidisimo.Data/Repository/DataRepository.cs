using Console.Migration.Context;
using Microsoft.EntityFrameworkCore;
using System;
using TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato;
using TestInterRapidisimo.Domain.Model.Response;

namespace StudentRegistration.API.Services;

public class DataRepository<T> : IDataRepository<T> where T : class
{
    private readonly SqlServerContext _context;

    public DataRepository(SqlServerContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método que consulta por un id especifico
    /// </summary>
    /// <returns></returns>

    public async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    /// <summary>
    /// Método que consulta todos los datos
    /// </summary>
    /// <returns></returns>
    public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

    /// <summary>
    /// Método que adiciona registros 
    /// </summary>
    /// <returns></returns>
    public async Task AddAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    /// <summary>
    /// Método que actualiza registros
    /// </summary>
    /// <returns></returns>
    public void Update(T entity)
        => _context.Set<T>().Update(entity);

    /// <summary>
    /// Método que elimina registros  
    /// </summary>
    /// <returns></returns>
    public void Remove(T entity)
        => _context.Set<T>().Remove(entity);
}
