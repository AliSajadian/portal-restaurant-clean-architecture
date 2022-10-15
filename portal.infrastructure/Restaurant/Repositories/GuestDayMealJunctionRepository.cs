namespace Portal.Infrastructure.Restaurant.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Restaurant.GuestDayMealJunctions;
using Application.Restaurant.GuestDayMealJunctions.Queries.Common;
using Application.Restaurant.GuestDayMealJunctions.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.Restaurant.Models.GuestDayMealJunctions;
using Domain.Restaurant.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Restaurant.Models.Meals;

internal class GuestDayMealJunctionRepository : DataRepository<IRestaurantDbContext, GuestDayMealJunction>,
    IGuestDayMealJunctionDomainRepository,
    IGuestDayMealJunctionQueryRepository
{
    public GuestDayMealJunctionRepository(
        IRestaurantDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<GuestDayMealJunction?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var guestDayMealJunction = await this.Data.GuestDayMealJunctions.FindAsync(id);

        if (guestDayMealJunction is null)
        {
            return false;
        }

        this.Data.GuestDayMealJunctions.Remove(guestDayMealJunction);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<GuestDayMealJunctionDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<GuestDayMealJunctionDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<GuestDayMealJunction> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetGuestDayMealJunctionsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<GuestDayMealJunctionResponseModel>> GetGuestDayMealJunctionsListing(
        Specification<GuestDayMealJunction> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<GuestDayMealJunctionResponseModel>(this
                .GetGuestDayMealJunctionsQuery(specification)
                .OrderBy(a => a.Id)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<GuestDayMealJunction> GetGuestDayMealJunctionsQuery(
        Specification<GuestDayMealJunction> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}