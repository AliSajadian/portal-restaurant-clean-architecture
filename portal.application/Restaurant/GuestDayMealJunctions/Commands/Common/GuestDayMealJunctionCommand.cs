namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Common;

using Application.Common;

public abstract class GuestDayMealJunctionCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public short Qty { get; init; } = default!;
    public int DayMealId { get; init; } = default!;
    public int GuestDayMealId { get; init; } = default!;
}