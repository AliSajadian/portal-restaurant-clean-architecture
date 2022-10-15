namespace Portal.Application.BaseInfo.Projects.Queries.Common;

using Application.Common.Mapping;
using Domain.BaseInfo.Models.Projects;

public class ProjectResponseModel : IMapFrom<Project>
{
    public string Name { get; private set; } = default!;
}