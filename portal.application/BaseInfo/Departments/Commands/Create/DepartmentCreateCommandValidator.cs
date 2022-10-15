namespace Portal.Application.BaseInfo.Departments.Commands.Create;

using Common;
using FluentValidation;

public class DepartmentCreateCommandValidator : AbstractValidator<DepartmentCreateCommand>
{
    public DepartmentCreateCommandValidator()
        => this.Include(new DepartmentCommandValidator<DepartmentCreateCommand>());
}