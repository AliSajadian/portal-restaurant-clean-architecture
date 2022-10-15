namespace Portal.Application.BaseInfo.Employees.Commands.Create;

using Common;
using FluentValidation;

public class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
{
    public EmployeeCreateCommandValidator()
        => this.Include(new EmployeeCommandValidator<EmployeeCreateCommand>());
}