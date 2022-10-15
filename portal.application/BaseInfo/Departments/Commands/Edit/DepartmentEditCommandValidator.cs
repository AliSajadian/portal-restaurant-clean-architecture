namespace Portal.Application.BaseInfo.Departments.Commands.Edit;

using Common;
using FluentValidation;

public class DepartmentEditCommandValidator : AbstractValidator<DepartmentEditCommand>
{
    public DepartmentEditCommandValidator()
        => this.Include(new DepartmentCommandValidator<DepartmentEditCommand>());
}