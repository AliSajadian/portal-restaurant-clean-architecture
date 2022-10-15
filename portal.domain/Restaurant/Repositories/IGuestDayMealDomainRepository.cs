namespace Portal.Domain.Restaurant.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.GuestDayMeals;
using Portal.Domain.BaseInfo.Models.Departments;
using Portal.Domain.BaseInfo.Models.Projects;

public interface IGuestDayMealDomainRepository : IDomainRepository<GuestDayMeal>
{
    Task<GuestDayMeal?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<List<GuestDayMeal>> Find(
        DateTime date,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}