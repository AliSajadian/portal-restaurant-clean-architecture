namespace Portal.Infrastructure.Restaurant.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Restaurant.Meals;
using Application.Restaurant.Meals.Queries.Common;
using Application.Restaurant.Meals.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.Restaurant.Models.Meals;
using Domain.Restaurant.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class MealRepository : DataRepository<IRestaurantDbContext, Meal>,
    IMealDomainRepository,
    IMealQueryRepository
{
    public MealRepository(
        IRestaurantDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Meal?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Meal?> Find(
        string name,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Name == name)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var meal = await this.Data.Meals.FindAsync(id);

        if (meal is null)
        {
            return false;
        }

        this.Data.Meals.Remove(meal);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<MealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<MealDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Meal> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetMealsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<MealResponseModel>> GetMealsListing(
        Specification<Meal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<MealResponseModel>(this
                .GetMealsQuery(specification)
                .OrderBy(a => a.Name)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Meal> GetMealsQuery(
        Specification<Meal> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}