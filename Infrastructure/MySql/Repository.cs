using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.MySql;

public class Repository<TEntity>(TravelersDbContext context) : IRepository<TEntity> where TEntity : class
{
    private readonly TravelersDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
         return await _dbSet.ToListAsync();
    }
}