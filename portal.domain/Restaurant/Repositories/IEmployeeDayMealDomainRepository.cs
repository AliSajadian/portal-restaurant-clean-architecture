namespace Portal.Domain.Restaurant.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.EmployeeDayMeals;
using Portal.Domain.BaseInfo.Models.Departments;
using Portal.Domain.BaseInfo.Models.Projects;

public interface IEmployeeDayMealDomainRepository : IDomainRepository<EmployeeDayMeal>
{
    Task<EmployeeDayMeal?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<List<EmployeeDayMeal>> Find(
        string personnelCode,
        CancellationToken cancellationToken = default);

    Task<List<EmployeeDayMeal>> Find(
        DateTime date,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}