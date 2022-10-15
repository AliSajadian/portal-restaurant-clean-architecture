namespace Portal.Application.BaseInfo.JobPositions.Queries.Common;

using Application.Common.Mapping;
using Domain.BaseInfo.Models.JobPositions;

public class JobPositionResponseModel : IMapFrom<JobPosition>
{
    public string Name { get; private set; } = default!;
}