namespace Portal.Application.BaseInfo.Companies.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Common;
using Domain.BaseInfo.Factories.Companies;
using Domain.BaseInfo.Repositories;
using MediatR;

public class CompanyCreateCommand : CompanyCommand<CompanyCreateCommand>, IRequest<Result<int>>
{
    public class CompanyCreateCommandHandler : IRequestHandler<CompanyCreateCommand, Result<int>>
    {
        private readonly ICompanyFactory companyFactory;
        private readonly ICompanyDomainRepository companyRepository;

        public CompanyCreateCommandHandler(
            ICompanyFactory companyFactory,
            ICompanyDomainRepository companyRepository)
        {
            this.companyFactory = companyFactory;
            this.companyRepository = companyRepository;
        }

        public async Task<Result<int>> Handle(
            CompanyCreateCommand request,
            CancellationToken cancellationToken)
        {
            var company = this.companyFactory
                .WithName(request.Name)
                .Build();

            await this.companyRepository.Save(company, cancellationToken);

            return company.Id;
        }
    }
}