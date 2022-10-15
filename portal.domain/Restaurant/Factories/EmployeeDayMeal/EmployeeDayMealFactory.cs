namespace Portal.Domain.Restaurant.Factories.EmployeeDayMeals;

using Exceptions;
using Portal.Domain.BaseInfo.Models.Employees;
using Models.DayMeals;
using Models.EmployeeDayMeals;

internal class EmployeeDayMealFactory : IEmployeeDayMealFactory
{
    private bool Served = default!;
    private Employee Employee = default!;
    private DayMeal DayMeal = default!;

    private bool isServedSet = false;
    private bool isEmployeeSet = false;
    private bool isDayMealSet = false;

    public IEmployeeDayMealFactory WithServed(bool served)
    {
        this.Served = served;
        this.isServedSet = true;

        return this;
    }

    public IEmployeeDayMealFactory FromEmployee(Employee employee)
    {
        this.Employee = employee;
        this.isEmployeeSet = true;

        return this;
    }

    public IEmployeeDayMealFactory FromDayMeal(DayMeal dayMeal)
    {
        this.DayMeal = dayMeal;
        this.isDayMealSet = true;

        return this;
    }

    public EmployeeDayMeal Build()
    {
        if (!this.isServedSet || !this.isEmployeeSet || !this.isDayMealSet)
        {
            throw new InvalidEmployeeDayMealException("Served, Employee and DayMeal must have a value.");
        }

        return new EmployeeDayMeal(this.Served, 
                           this.Employee, 
                           this.DayMeal);
    }
}