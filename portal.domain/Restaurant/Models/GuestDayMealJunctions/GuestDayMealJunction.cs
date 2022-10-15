using System.Globalization;
namespace Portal.Domain.Restaurant.Models.GuestDayMealJunctions;

using Portal.Domain.BaseInfo.Models.Departments;
using Portal.Domain.BaseInfo.Models.Projects;
using Models.DayMeals;
using Models.GuestDayMeals;
using Common;
using Common.Models;
using Exceptions;

using static ModelConstants.GuestDayMealJunction;
//using static Common.Models.ModelConstants.Common;

public class GuestDayMealJunction : Entity<int>, IAggregateRoot
{
    internal GuestDayMealJunction(short qty,
                     DayMeal dayMeal,
                     GuestDayMeal guestDayMeal)
    {
        this.Validate(qty);

        this.Qty = qty;
        this.DayMeal = dayMeal;
        this.GuestDayMeal = guestDayMeal;
    }

    public short Qty { get; private set; }
    public DayMeal DayMeal { get; private set; }
    public GuestDayMeal GuestDayMeal { get; private set; }


    public GuestDayMealJunction UpdateQty(short qty)
    {
        // this.ValidateDate(date);

        this.Qty = qty;

        return this;
    }
    public GuestDayMealJunction UpdateDayMeal(DayMeal dayMeal)
    {
        // this.ValidateDayMeal(dayMeal);

        this.DayMeal = dayMeal;

        return this;
    }
    public GuestDayMealJunction UpdateGuestDayMeal(GuestDayMeal guestDayMeal)
    {
        // this.ValidateGuestDayMeal(guestDayMeal);

        this.GuestDayMeal = guestDayMeal;

        return this;
    }

    private void Validate(short qty)
    {
        this.ValidateQty(qty);
        // this.ValidateTotalNo(totalNo);
        // this.ValidateIsActive(isActive);
    }

    private void ValidateQty(short qty)
        => Validations.AgainstOutOfRange<InvalidGuestDayMealException>(
            (int)qty,
            MinQty,
            MaxQty,
            nameof(this.Qty));

    // private void ValidateTotalNo(int totalNo)
    //     => Validations.ForStringLength<InvalidDayMealException>(
    //         totalNo,
    //         MinNameLength,
    //         MaxNameLength,
    //         nameof(this.TotalNo));
    // private void ValidateIsActive(bool isActive)
    //     => Validations.ForStringLength<InvalidDayMealException>(
    //         isActive,
    //         MinNameLength,
    //         MaxNameLength,
    //         nameof(this.IsActive));                 
}