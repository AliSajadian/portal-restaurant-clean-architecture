namespace Portal.Application.Restaurant.GuestDayMeals;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Restaurant.Models.GuestDayMeals;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IGuestDayMealQueryRepository : IQueryRepository<GuestDayMeal>
{
    Task<GuestDayMealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<GuestDayMeal> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<GuestDayMealResponseModel>> GetGuestDayMealsListing(
        Specification<GuestDayMeal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}