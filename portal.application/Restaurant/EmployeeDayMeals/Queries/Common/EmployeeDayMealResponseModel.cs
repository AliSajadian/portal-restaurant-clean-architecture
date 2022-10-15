namespace Portal.Application.Restaurant.EmployeeDayMeals.Queries.Common;

using Application.Common.Mapping;
using Domain.Restaurant.Models.EmployeeDayMeals;

public class EmployeeDayMealResponseModel : IMapFrom<EmployeeDayMeal>
{
    public int Id { get; private set; }
    public bool Served { get; private set; } = default!;
    public string PersonelCode { get; private set; } = default!;
    public int DayMealId { get; private set; } = default!;
}