namespace Portal.Application.Restaurant.Meals.Queries.Common;

using Application.Common.Mapping;
using Domain.Restaurant.Models.Meals;

public class MealResponseModel : IMapFrom<Meal>
{
    public string Name { get; private set; } = default!;
}