namespace Portal.Application.BaseInfo.Companies;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.BaseInfo.Models.Companies;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface ICompanyQueryRepository : IQueryRepository<Company>
{
    Task<CompanyDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Company> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<CompanyResponseModel>> GetCompaniesListing(
        Specification<Company> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}