namespace Portal.Application.Restaurant.Meals.Commands.Common;

using Application.Common;

public abstract class MealCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Name { get; init; } = default!;
}