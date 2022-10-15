namespace Portal.Application.Restaurant.GuestDayMealJunctions.Queries.Common;

using Application.Common.Mapping;
using Domain.Restaurant.Models.GuestDayMealJunctions;

public class GuestDayMealJunctionResponseModel : IMapFrom<GuestDayMealJunction>
{
    public int Id { get; private set; }
    public short Qty { get; private set; } = default!;
    public int DayMealId { get; private set; } = default!;
    public int GuestDayMealId { get; private set; } = default!;

}