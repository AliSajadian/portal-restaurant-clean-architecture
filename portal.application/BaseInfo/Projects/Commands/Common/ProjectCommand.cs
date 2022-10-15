namespace Portal.Application.BaseInfo.Projects.Commands.Common;

using Domain.BaseInfo.Models.Companies;
using Application.Common;

public abstract class ProjectCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Name { get; init; } = default!;

    public string Company { get; init; } = default!;
}