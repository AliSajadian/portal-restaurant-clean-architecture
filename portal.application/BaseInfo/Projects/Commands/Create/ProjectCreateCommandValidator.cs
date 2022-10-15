namespace Portal.Application.BaseInfo.Projects.Commands.Create;

using Common;
using FluentValidation;

public class ProjectCreateCommandValidator : AbstractValidator<ProjectCreateCommand>
{
    public ProjectCreateCommandValidator()
        => this.Include(new ProjectCommandValidator<ProjectCreateCommand>());
}