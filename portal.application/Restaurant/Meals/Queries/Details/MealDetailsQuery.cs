namespace Portal.Application.Restaurant.Meals.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class MealDetailsQuery : IRequest<MealDetailsResponseModel?>
{
    public int Id { get; init; }

    public class MealDetailsQueryHandler : IRequestHandler<MealDetailsQuery, MealDetailsResponseModel?>
    {
        private readonly IMealQueryRepository mealRepository;

        public MealDetailsQueryHandler(IMealQueryRepository mealRepository)
            => this.mealRepository = mealRepository;

        public async Task<MealDetailsResponseModel?> Handle(
            MealDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.mealRepository.Details(
                request.Id,
                cancellationToken);
    }
}