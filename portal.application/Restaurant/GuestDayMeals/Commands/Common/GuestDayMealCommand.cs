namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Common;

using Application.Common;

public abstract class GuestDayMealCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public DateTime Date { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string Department { get; init; } = default!;
    public string Project { get; init; } = default!;
}