namespace Portal.Application.BaseInfo.Departments.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class DepartmentDetailsQuery : IRequest<DepartmentDetailsResponseModel?>
{
    public int Id { get; init; }

    public class DepartmentDetailsQueryHandler : IRequestHandler<DepartmentDetailsQuery, DepartmentDetailsResponseModel?>
    {
        private readonly IDepartmentQueryRepository departmentRepository;

        public DepartmentDetailsQueryHandler(IDepartmentQueryRepository departmentRepository)
            => this.departmentRepository = departmentRepository;

        public async Task<DepartmentDetailsResponseModel?> Handle(
            DepartmentDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.departmentRepository.Details(
                request.Id,
                cancellationToken);
    }
}