namespace Portal.Application.Restaurant.GuestDayMeals.Queries.Common;

using Application.Common.Mapping;
using Domain.Restaurant.Models.GuestDayMeals;

public class GuestDayMealResponseModel : IMapFrom<GuestDayMeal>
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; } = default!;
    public string Department { get; private set; } = default!;
    public string Project { get; private set; } = default!;

}