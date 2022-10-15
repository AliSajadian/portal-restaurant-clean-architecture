namespace Portal.Application.Restaurant.EmployeeDayMeals.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class EmployeeDayMealDetailsQuery : IRequest<EmployeeDayMealDetailsResponseModel?>
{
    public int Id { get; init; }

    public class EmployeeDayMealDetailsQueryHandler : IRequestHandler<EmployeeDayMealDetailsQuery, EmployeeDayMealDetailsResponseModel?>
    {
        private readonly IEmployeeDayMealQueryRepository employeeDayMealRepository;

        public EmployeeDayMealDetailsQueryHandler(IEmployeeDayMealQueryRepository employeeDayMealRepository)
            => this.employeeDayMealRepository = employeeDayMealRepository;

        public async Task<EmployeeDayMealDetailsResponseModel?> Handle(
            EmployeeDayMealDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.employeeDayMealRepository.Details(
                request.Id,
                cancellationToken);
    }
}