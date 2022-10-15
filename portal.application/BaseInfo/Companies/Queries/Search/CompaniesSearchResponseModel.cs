namespace Portal.Application.BaseInfo.Companies.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class CompaniesSearchResponseModel : PaginatedResponseModel<CompanyResponseModel>
{
    internal CompaniesSearchResponseModel(
        IEnumerable<CompanyResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}