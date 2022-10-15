namespace Portal.Application.Restaurant.DayMeals.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class DayMealDetailsQuery : IRequest<DayMealDetailsResponseModel?>
{
    public int Id { get; init; }

    public class DayMealDetailsQueryHandler : IRequestHandler<DayMealDetailsQuery, DayMealDetailsResponseModel?>
    {
        private readonly IDayMealQueryRepository dayMealRepository;

        public DayMealDetailsQueryHandler(IDayMealQueryRepository dayMealRepository)
            => this.dayMealRepository = dayMealRepository;

        public async Task<DayMealDetailsResponseModel?> Handle(
            DayMealDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.dayMealRepository.Details(
                request.Id,
                cancellationToken);
    }
}