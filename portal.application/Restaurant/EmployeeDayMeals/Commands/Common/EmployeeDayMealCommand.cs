namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Common;

using Application.Common;

public abstract class EmployeeDayMealCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public bool Served { get; init; } = default!;
    public string PersonelCode { get; init; } = default!;
    public int DayMealId { get; init; } = default!;
}