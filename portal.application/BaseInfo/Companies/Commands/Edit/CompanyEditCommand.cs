namespace Portal.Application.BaseInfo.Companies.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.BaseInfo.Repositories;
using MediatR;

public class CompanyEditCommand : CompanyCommand<CompanyEditCommand>, IRequest<Result<int>>
{
    public class CompanyEditCommandHandler : IRequestHandler<CompanyEditCommand, Result<int>>
    {
        private readonly ICompanyDomainRepository companyRepository;

        public CompanyEditCommandHandler(ICompanyDomainRepository companyRepository)
            => this.companyRepository = companyRepository;

        public async Task<Result<int>> Handle(
            CompanyEditCommand request,
            CancellationToken cancellationToken)
        {
            var company = await this.companyRepository.Find(
                request.Id,
                cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(company), request.Id);
            }

            company.UpdateName(request.Name);

            await this.companyRepository.Save(company, cancellationToken);

            return company.Id;
        }
    }
}