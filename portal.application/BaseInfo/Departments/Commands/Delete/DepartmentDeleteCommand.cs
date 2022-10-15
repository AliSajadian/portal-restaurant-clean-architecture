namespace Portal.Application.BaseInfo.Departments.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.BaseInfo.Repositories;
using MediatR;

public class DepartmentDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class DepartmentDeleteCommandHandler : IRequestHandler<DepartmentDeleteCommand, Result>
    {
        private readonly IDepartmentDomainRepository departmentRepository;

        public DepartmentDeleteCommandHandler(IDepartmentDomainRepository departmentRepository)
            => this.departmentRepository = departmentRepository;

        public async Task<Result> Handle(
            DepartmentDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.departmentRepository.Delete(
                request.Id,
                cancellationToken);
    }
}