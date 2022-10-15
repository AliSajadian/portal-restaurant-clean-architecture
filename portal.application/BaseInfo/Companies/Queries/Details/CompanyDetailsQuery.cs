namespace Portal.Application.BaseInfo.Companies.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class CompanyDetailsQuery : IRequest<CompanyDetailsResponseModel?>
{
    public int Id { get; init; }

    public class CompanyDetailsQueryHandler : IRequestHandler<CompanyDetailsQuery, CompanyDetailsResponseModel?>
    {
        private readonly ICompanyQueryRepository companyRepository;

        public CompanyDetailsQueryHandler(ICompanyQueryRepository companyRepository)
            => this.companyRepository = companyRepository;

        public async Task<CompanyDetailsResponseModel?> Handle(
            CompanyDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.companyRepository.Details(
                request.Id,
                cancellationToken);
    }
}