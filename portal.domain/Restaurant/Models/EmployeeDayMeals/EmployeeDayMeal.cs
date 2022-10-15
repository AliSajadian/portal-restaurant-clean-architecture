using System.Globalization;
namespace Portal.Domain.Restaurant.Models.EmployeeDayMeals;

using Portal.Domain.BaseInfo.Models.Employees;
using DayMeals;
using Common;
using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;
//using static ModelConstants.Common;

public class EmployeeDayMeal : Entity<int>, IAggregateRoot
{
    internal EmployeeDayMeal(bool served, 
                            Employee employee,
                            DayMeal dayMeal)
    {
        // this.Validate(date);

        this.Served = served;
        this.Employee = employee;
        this.DayMeal = dayMeal;
    }

    public bool Served { get; private set; }
    public Employee Employee { get; private set; }
    public DayMeal DayMeal { get; private set; }

    public EmployeeDayMeal UpdateServed(bool served)
    {
        // this.ValidateServed(date);

        this.Served = served;

        return this;
    }
    public EmployeeDayMeal UpdateEmployee(Employee employee)
    {
        // this.ValidateEmployee(totalNo);

        this.Employee = employee;

        return this;
    }
    public EmployeeDayMeal UpdateDayMeal(DayMeal dayMeal)
    {
        // this.ValidateDayMeal(isActive);

        this.DayMeal = dayMeal;

        return this;
    }

    // private void Validate(DateTime date, int totalNo, bool isActive)
    // {
    //     this.ValidateDate(date);
    //     this.ValidateTotalNo(totalNo);
    //     this.ValidateIsActive(isActive);
    // }

    // private void ValidateDate(DateTime date)
    //     => Validations.ForStringLength<InvalidDayMealException>(
    //         date,
    //         MinNameLength,
    //         MaxNameLength,
    //         nameof(this.Date));
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