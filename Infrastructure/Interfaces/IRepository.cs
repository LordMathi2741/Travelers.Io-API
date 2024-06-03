namespace Infrastructure.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
}