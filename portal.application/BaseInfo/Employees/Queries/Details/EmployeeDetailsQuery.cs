namespace Portal.Application.BaseInfo.Employees.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class EmployeeDetailsQuery : IRequest<EmployeeDetailsResponseModel?>
{
    public int Id { get; init; }

    public class EmployeeDetailsQueryHandler : IRequestHandler<EmployeeDetailsQuery, EmployeeDetailsResponseModel?>
    {
        private readonly IEmployeeQueryRepository employeeRepository;

        public EmployeeDetailsQueryHandler(IEmployeeQueryRepository employeeRepository)
            => this.employeeRepository = employeeRepository;

        public async Task<EmployeeDetailsResponseModel?> Handle(
            EmployeeDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.employeeRepository.Details(
                request.Id,
                cancellationToken);
    }
}