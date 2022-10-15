namespace Portal.Application.Restaurant.DayMeals;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Restaurant.Models.DayMeals;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IDayMealQueryRepository : IQueryRepository<DayMeal>
{
    Task<DayMealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<DayMeal> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<DayMealResponseModel>> GetDayMealsListing(
        Specification<DayMeal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}