namespace Portal.Application.BaseInfo.Companies.Commands.Common;

using Application.Common;

public abstract class CompanyCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Name { get; init; } = default!;
}