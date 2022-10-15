namespace Portal.Application.BaseInfo.Employees.Queries.Search;

using System;
using System.Linq.Expressions;
using Application.Common;
using Domain.BaseInfo.Models.Employees;

public class EmployeesSearchSortOrder : SortOrder<Employee>
{
    public EmployeesSearchSortOrder(string? sortBy, string? order)
        : base(sortBy, order)
    {
    }

    public override Expression<Func<Employee, object>> ToExpression()
        => this.SortBy switch
        {
            "personnelCode" => employee => employee.PersonelCode,
            "lastName" => employee => employee.LastName,
            "Company" => employee => employee.Department.Company.Name,
            "department" => employee => employee.Department.Name,
            "project" => employee => employee.Project.Name,
                    _ => employee => employee.Id
        };
}