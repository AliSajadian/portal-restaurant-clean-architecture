namespace Portal.Application.Restaurant.GuestDayMeals.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GuestDayMealDetailsQuery : IRequest<GuestDayMealDetailsResponseModel?>
{
    public int Id { get; init; }

    public class GuestDayMealDetailsQueryHandler : IRequestHandler<GuestDayMealDetailsQuery, GuestDayMealDetailsResponseModel?>
    {
        private readonly IGuestDayMealQueryRepository guestDayMealRepository;

        public GuestDayMealDetailsQueryHandler(IGuestDayMealQueryRepository guestDayMealRepository)
            => this.guestDayMealRepository = guestDayMealRepository;

        public async Task<GuestDayMealDetailsResponseModel?> Handle(
            GuestDayMealDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.guestDayMealRepository.Details(
                request.Id,
                cancellationToken);
    }
}