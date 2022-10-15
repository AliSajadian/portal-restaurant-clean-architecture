namespace Portal.Application.Restaurant.Meals;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Restaurant.Models.Meals;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IMealQueryRepository : IQueryRepository<Meal>
{
    Task<MealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Meal> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<MealResponseModel>> GetMealsListing(
        Specification<Meal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}