namespace Portal.Application.BaseInfo.Employees.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.BaseInfo.Repositories;
using MediatR;

public class EmployeeDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class EmployeeDeleteCommandHandler : IRequestHandler<EmployeeDeleteCommand, Result>
    {
        private readonly IEmployeeDomainRepository employeeRepository;

        public EmployeeDeleteCommandHandler(IEmployeeDomainRepository employeeRepository)
            => this.employeeRepository = employeeRepository;

        public async Task<Result> Handle(
            EmployeeDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.employeeRepository.Delete(
                request.Id,
                cancellationToken);
    }
}