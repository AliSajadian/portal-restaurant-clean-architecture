namespace Portal.Application.BaseInfo.Employees.Commands.Edit;

using Common;
using FluentValidation;

public class EmployeeEditCommandValidator : AbstractValidator<EmployeeEditCommand>
{
    public EmployeeEditCommandValidator()
        => this.Include(new EmployeeCommandValidator<EmployeeEditCommand>());
}