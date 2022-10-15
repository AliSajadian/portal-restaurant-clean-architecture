namespace Portal.Infrastructure.Restaurant.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Restaurant.DayMeals;
using Application.Restaurant.DayMeals.Queries.Common;
using Application.Restaurant.DayMeals.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.Restaurant.Models.DayMeals;
using Domain.Restaurant.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Restaurant.Models.Meals;

internal class DayMealRepository : DataRepository<IRestaurantDbContext, DayMeal>,
    IDayMealDomainRepository,
    IDayMealQueryRepository
{
    public DayMealRepository(
        IRestaurantDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<DayMeal?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<List<DayMeal>> Find(
        DateTime date,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Date == date)
            .ToListAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var dayMeal = await this.Data.DayMeals.FindAsync(id);

        if (dayMeal is null)
        {
            return false;
        }

        this.Data.DayMeals.Remove(dayMeal);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<DayMealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<DayMealDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<DayMeal> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetDayMealsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<DayMealResponseModel>> GetDayMealsListing(
        Specification<DayMeal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<DayMealResponseModel>(this
                .GetDayMealsQuery(specification)
                .OrderBy(a => a.Date)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<DayMeal> GetDayMealsQuery(
        Specification<DayMeal> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}