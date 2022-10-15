namespace Portal.Application.BaseInfo.Employees.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class EmployeesSearchResponseModel : PaginatedResponseModel<EmployeeResponseModel>
{
    internal EmployeesSearchResponseModel(
        IEnumerable<EmployeeResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}