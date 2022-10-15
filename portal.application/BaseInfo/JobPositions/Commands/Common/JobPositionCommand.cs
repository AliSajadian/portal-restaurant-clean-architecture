namespace Portal.Application.BaseInfo.JobPositions.Commands.Common;

using Application.Common;

public abstract class JobPositionCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Name { get; init; } = default!;
}