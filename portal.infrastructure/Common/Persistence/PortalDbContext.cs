namespace Portal.Infrastructure.Common.Persistence;

using System.Reflection;
using BaseInfo;
using Domain.BaseInfo.Models.Companies;
using Domain.BaseInfo.Models.Departments;
using Domain.BaseInfo.Models.Projects;
using Domain.BaseInfo.Models.JobPositions;
using Domain.BaseInfo.Models.Employees;
using Domain.Restaurant.Models.Meals;
using Domain.Restaurant.Models.DayMeals;
using Domain.Restaurant.Models.EmployeeDayMeals;
using Domain.Restaurant.Models.GuestDayMealJunctions;
using Domain.Restaurant.Models.GuestDayMeals;
using Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant;

internal class PortalDbContext : IdentityDbContext<User>,
    IBaseInfoDbContext,
    IRestaurantDbContext
{
    public PortalDbContext(DbContextOptions<PortalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; } = default!;
    public virtual DbSet<Department> Departments { get; set; } = default!;
    public virtual DbSet<Project> Projects { get; set; } = default!;
    public virtual DbSet<JobPosition> JobPositions { get; set; } = default!;
    public virtual DbSet<Employee> Employees { get; set; } = default!;
    // public virtual DbSet<> TblBaseNotifications { get; set; } = default!;
    public virtual DbSet<Meal> Meals { get; set; } = default!;
    public virtual DbSet<DayMeal> DayMeals { get; set; } = default!;
    public virtual DbSet<EmployeeDayMeal> EmployeeDayMeals { get; set; } = default!;
    public virtual DbSet<GuestDayMealJunction> GuestDayMealJunctions { get; set; } = default!;
    public virtual DbSet<GuestDayMeal> GuestDayMeals { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}