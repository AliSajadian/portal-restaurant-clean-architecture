namespace Portal.Application.Restaurant.DayMeals.Queries.Common;

using Application.Common.Mapping;
using Domain.Restaurant.Models.DayMeals;

public class DayMealResponseModel : IMapFrom<DayMeal>
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; } = default!;
    public int TotalNo { get; private set; } = default!;
    public bool IsActive { get; private set; } = default!;
    public string Meal { get; private set; } = default!;
}