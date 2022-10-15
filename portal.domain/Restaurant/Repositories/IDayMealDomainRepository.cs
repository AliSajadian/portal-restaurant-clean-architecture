namespace Portal.Domain.Restaurant.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.DayMeals;

public interface IDayMealDomainRepository : IDomainRepository<DayMeal>
{
    Task<DayMeal?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<List<DayMeal>> Find(
        DateTime date,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}