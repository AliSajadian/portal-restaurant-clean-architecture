namespace Portal.Application.BaseInfo.Projects.Commands.Edit;

using Common;
using FluentValidation;

public class ProjectEditCommandValidator : AbstractValidator<ProjectEditCommand>
{
    public ProjectEditCommandValidator()
        => this.Include(new ProjectCommandValidator<ProjectEditCommand>());
}