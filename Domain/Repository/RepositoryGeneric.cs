using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.subscription.Model;

namespace Domain.Repository;

public class RepositoryGeneric<TEntity>(IRepository<TEntity>repository) : IRepositoryGeneric<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity)
    {
        if (entity is Plan plan)
        {
            var plans = await repository.GetAllAsync() as List<Plan>;
            bool haveDefaultPlan = plans.Any(p => p.IsDefalut == 1);
            if (plan.IsDefalut == 1 && haveDefaultPlan)
            {
                throw new Exception("There is already a default plan");
            }
            if (plans.Any(p => p.Name == plan.Name))
            {
                throw new Exception("Plan already exists");
            }
            if (plan.MaxUsers <= 0)
            {
                throw new Exception("MaxUsers must be greater than 0");
            }

            if (plan.IsDefalut is > 1 or < 0)
            {
                throw new Exception("IsDefault must be 0 or 1");
            }
        }
        await repository.AddAsync(entity);
    }
}