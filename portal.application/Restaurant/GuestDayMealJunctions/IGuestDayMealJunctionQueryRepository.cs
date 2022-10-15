namespace Portal.Application.Restaurant.GuestDayMealJunctions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Restaurant.Models.GuestDayMealJunctions;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IGuestDayMealJunctionQueryRepository : IQueryRepository<GuestDayMealJunction>
{
    Task<GuestDayMealJunctionDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<GuestDayMealJunction> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<GuestDayMealJunctionResponseModel>> GetGuestDayMealJunctionsListing(
        Specification<GuestDayMealJunction> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}