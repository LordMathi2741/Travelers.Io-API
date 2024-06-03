namespace Domain.Interfaces;

public interface IRepositoryGeneric<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
}