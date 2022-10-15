namespace Portal.Domain.Restaurant.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Meals;

public interface IMealDomainRepository : IDomainRepository<Meal>
{
    Task<Meal?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<Meal?> Find(
        string name,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}