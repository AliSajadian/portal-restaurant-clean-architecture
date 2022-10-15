namespace Portal.Application.BaseInfo.Companies.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.BaseInfo.Repositories;
using MediatR;

public class CompanyDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class CompanyDeleteCommandHandler : IRequestHandler<CompanyDeleteCommand, Result>
    {
        private readonly ICompanyDomainRepository companyRepository;

        public CompanyDeleteCommandHandler(ICompanyDomainRepository companyRepository)
            => this.companyRepository = companyRepository;

        public async Task<Result> Handle(
            CompanyDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.companyRepository.Delete(
                request.Id,
                cancellationToken);
    }
}