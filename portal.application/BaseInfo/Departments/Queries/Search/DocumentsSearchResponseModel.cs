namespace Portal.Application.BaseInfo.Departments.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class DepartmentsSearchResponseModel : PaginatedResponseModel<DepartmentResponseModel>
{
    internal DepartmentsSearchResponseModel(
        IEnumerable<DepartmentResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}