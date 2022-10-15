namespace Portal.Domain.Restaurant.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.GuestDayMealJunctions;

public interface IGuestDayMealJunctionDomainRepository : IDomainRepository<GuestDayMealJunction>
{
    Task<GuestDayMealJunction?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}