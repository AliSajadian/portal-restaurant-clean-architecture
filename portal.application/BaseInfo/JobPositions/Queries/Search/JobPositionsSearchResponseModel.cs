namespace Portal.Application.BaseInfo.JobPositions.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class JobPositionsSearchResponseModel : PaginatedResponseModel<JobPositionResponseModel>
{
    internal JobPositionsSearchResponseModel(
        IEnumerable<JobPositionResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}