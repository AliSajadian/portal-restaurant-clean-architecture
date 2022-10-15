namespace Portal.Application.BaseInfo.Projects.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class ProjectsSearchResponseModel : PaginatedResponseModel<ProjectResponseModel>
{
    internal ProjectsSearchResponseModel(
        IEnumerable<ProjectResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}