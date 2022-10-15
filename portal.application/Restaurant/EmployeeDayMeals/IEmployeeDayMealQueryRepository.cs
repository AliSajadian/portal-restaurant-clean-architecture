namespace Portal.Application.Restaurant.EmployeeDayMeals;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Restaurant.Models.EmployeeDayMeals;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IEmployeeDayMealQueryRepository : IQueryRepository<EmployeeDayMeal>
{
    Task<EmployeeDayMealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<EmployeeDayMeal> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<EmployeeDayMealResponseModel>> GetEmployeeDayMealsListing(
        Specification<EmployeeDayMeal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}