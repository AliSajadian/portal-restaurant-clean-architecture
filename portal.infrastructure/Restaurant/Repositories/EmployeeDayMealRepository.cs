namespace Portal.Infrastructure.Restaurant.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Restaurant.EmployeeDayMeals;
using Application.Restaurant.EmployeeDayMeals.Queries.Common;
using Application.Restaurant.EmployeeDayMeals.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.Restaurant.Models.EmployeeDayMeals;
using Domain.Restaurant.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Restaurant.Models.Meals;

internal class EmployeeDayMealRepository : DataRepository<IRestaurantDbContext, EmployeeDayMeal>,
    IEmployeeDayMealDomainRepository,
    IEmployeeDayMealQueryRepository
{
    public EmployeeDayMealRepository(
        IRestaurantDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<EmployeeDayMeal?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<List<EmployeeDayMeal>> Find(
        string personelCode,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Employee.PersonelCode == personelCode)
            .ToListAsync(cancellationToken);

    public async Task<List<EmployeeDayMeal>> Find(
        DateTime date,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.DayMeal.Date.Date == date.Date)
            .ToListAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var employeeDayMeal = await this.Data.EmployeeDayMeals.FindAsync(id);

        if (employeeDayMeal is null)
        {
            return false;
        }

        this.Data.EmployeeDayMeals.Remove(employeeDayMeal);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<EmployeeDayMealDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<EmployeeDayMealDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<EmployeeDayMeal> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetEmployeeDayMealsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<EmployeeDayMealResponseModel>> GetEmployeeDayMealsListing(
        Specification<EmployeeDayMeal> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<EmployeeDayMealResponseModel>(this
                .GetEmployeeDayMealsQuery(specification)
                .OrderBy(a => a.DayMeal.Date)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<EmployeeDayMeal> GetEmployeeDayMealsQuery(
        Specification<EmployeeDayMeal> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}