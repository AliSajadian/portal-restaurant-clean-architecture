namespace Portal.Infrastructure.Restaurant.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Restaurant.GuestDayMeals;
using Application.Restaurant.GuestDayMeals.Queries.Common;
using Application.Restaurant.GuestDayMeals.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.Restaurant.Models.GuestDayMeals;
using Domain.Restaurant.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Restaurant.Models.Meals;

internal class GuestDayMealRepository : DataRepository<IRestaurantDbContext, GuestDayMeal>,
    IGuestDayMealDomainRepository,
    IGuestDayMealQueryRepository
{
    public GuestDayMealRepository(
        IRestaurantDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<GuestDayMeal?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<List<GuestDayMeal>> Find(
        DateTime date,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Date.Date == date.Date)
            .ToListAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var guestDayMeal = await this.Data.GuestDayMeals.FindAsync(id);

        if (guestDayMeal is null)
        {
            return false;
        }

        this.Data.GuestDayMeals.Remove(guestDayMeal);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<GuestDayMealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<GuestDayMealDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<GuestDayMeal> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetGuestDayMealsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<GuestDayMealResponseModel>> GetGuestDayMealsListing(
        Specification<GuestDayMeal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<GuestDayMealResponseModel>(this
                .GetGuestDayMealsQuery(specification)
                .OrderBy(a => a.Date)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<GuestDayMeal> GetGuestDayMealsQuery(
        Specification<GuestDayMeal> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}