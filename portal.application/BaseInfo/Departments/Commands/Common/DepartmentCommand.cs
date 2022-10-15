namespace Portal.Application.BaseInfo.Departments.Commands.Common;

using Domain.BaseInfo.Models.Companies;
using Application.Common;

public abstract class DepartmentCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Name { get; init; } = default!;
    public string Company { get; init; } = default!;
}