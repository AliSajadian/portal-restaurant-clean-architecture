namespace Portal.Domain.Restaurant.Specifications.EmployeeDayMeals;

using System;
using System.Linq.Expressions;
using Common;
using Models.EmployeeDayMeals;

public class EmployeeDayMealByDateSpecification : Specification<EmployeeDayMeal>
{
    private readonly string? date;

    public EmployeeDayMealByDateSpecification(string? date) => this.date = date;

    protected override bool Include => this.date != null;

    public override Expression<Func<EmployeeDayMeal, bool>> ToExpression()
        => employeeDayMeal => employeeDayMeal.DayMeal != null && 
            employeeDayMeal.DayMeal.Date.Date.ToString().ToLower()
                    .Contains(this.date!.ToLower());}