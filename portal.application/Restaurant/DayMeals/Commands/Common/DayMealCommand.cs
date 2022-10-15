namespace Portal.Application.Restaurant.DayMeals.Commands.Common;

using Application.Common;

public abstract class DayMealCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public DateTime Date { get; init; } = default!;
    public int TotalNo { get; init; } = default!;
    public bool IsActive { get; init; } = default!;
    public string Meal { get; init; } = default!;
}