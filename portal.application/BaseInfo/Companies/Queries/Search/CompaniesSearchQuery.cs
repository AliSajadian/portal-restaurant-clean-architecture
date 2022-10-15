namespace Portal.Application.BaseInfo.Companies.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.BaseInfo.Models.Companies;
using Domain.BaseInfo.Specifications.Companies;
using Domain.Common;
using MediatR;

public class CompaniesSearchQuery : IRequest<CompaniesSearchResponseModel>
{
    private const int CompaniesPerPage = 10;

    public string? Name { get; init; }

    public int Page { get; init; } = 1;

    public class CompaniesSearchQueryHandler : IRequestHandler<CompaniesSearchQuery, CompaniesSearchResponseModel>
    {
        private readonly ICompanyQueryRepository companyRepository;

        public CompaniesSearchQueryHandler(ICompanyQueryRepository companyRepository)
            => this.companyRepository = companyRepository;

        public async Task<CompaniesSearchResponseModel> Handle(
            CompaniesSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetCompanySpecification(request);

            var skip = (request.Page - 1) * CompaniesPerPage;

            var companiesListing = await this.companyRepository.GetCompaniesListing(
                specification,
                skip,
                take: CompaniesPerPage,
                cancellationToken);

            var totalCompanies = await this.companyRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalCompanies / CompaniesPerPage);

            return new CompaniesSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<Company> GetCompanySpecification(
            CompaniesSearchQuery request)
            => new CompanyByNameSpecification(request.Name);
    }
}