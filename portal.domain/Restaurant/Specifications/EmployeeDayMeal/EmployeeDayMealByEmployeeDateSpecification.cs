namespace Portal.Domain.Restaurant.Specifications.EmployeeDayMeals;

using System;
using System.Linq.Expressions;
using Common;
using Models.EmployeeDayMeals;

public class EmployeeDayMealByEmployeeSpecification : Specification<EmployeeDayMeal>
{
    private readonly string? personelCode;

    public EmployeeDayMealByEmployeeSpecification(string? personelCode) => this.personelCode = personelCode;

    protected override bool Include => this.personelCode != null;

    public override Expression<Func<EmployeeDayMeal, bool>> ToExpression()
        => employeeDayMeal => employeeDayMeal.Employee != null && 
                                employeeDayMeal.Employee.PersonelCode.ToLower()
                                    .Contains(this.personelCode!.ToLower());
}