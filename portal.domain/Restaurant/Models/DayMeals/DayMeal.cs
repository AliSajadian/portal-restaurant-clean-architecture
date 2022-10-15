using System.Globalization;
namespace Portal.Domain.Restaurant.Models.DayMeals;

using Meals;
using Common;
using Common.Models;
using Exceptions;

//using static Common.Models.ModelConstants.Common;
using static ModelConstants.DayMeal;

public class DayMeal : Entity<int>, IAggregateRoot
{
    internal DayMeal(DateTime date, 
                     int? totalNo,
                     bool? isActive,
                     Meal meal)
    {
        this.Validate(totalNo);

        this.Date = date;
        this.TotalNo = totalNo;
        this.IsActive = isActive;
        this.Meal = meal;
    }

    public DateTime Date { get; private set; }
    public int? TotalNo { get; private set; }
    public bool? IsActive { get; private set; }
    public Meal Meal { get; private set; }

    public DayMeal UpdateDate(DateTime date)
    {
        // this.ValidateDate(date);

        this.Date = date;

        return this;
    }
    public DayMeal UpdateTotalNo(int? totalNo)
    {
        // this.ValidateTotalNo(totalNo);

        this.TotalNo = totalNo;

        return this;
    }
    public DayMeal UpdateIsActive(bool? isActive)
    {
        // this.ValidateIsActive(isActive);

        this.IsActive = isActive;

        return this;
    }
    public DayMeal UpdateMeal(Meal meal)
    {
        this.Meal = meal;

        return this;
    }

    private void Validate(int? totalNo)
    {
        // this.ValidateDate(date);

        this.ValidateTotalNo(totalNo);
    }
    private void ValidateTotalNo(int? totalNo)
        => Validations.AgainstOutOfRangeNullable<InvalidDayMealException>(
            totalNo,
            MinTotalNo,
            MaxTotalNo,
            nameof(this.TotalNo));

    // private void ValidateDate(DateTime date)
    //     => Validations.ForStringLength<InvalidDayMealException>(
    //         date,
    //         MinNameLength,
    //         MaxNameLength,
    //         nameof(this.Date));
}