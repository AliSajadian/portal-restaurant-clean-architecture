namespace Portal.Application.Restaurant.GuestDayMealJunctions.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GuestDayMealJunctionDetailsQuery : IRequest<GuestDayMealJunctionDetailsResponseModel?>
{
    public int Id { get; init; }

    public class GuestDayMealJunctionDetailsQueryHandler : IRequestHandler<GuestDayMealJunctionDetailsQuery, GuestDayMealJunctionDetailsResponseModel?>
    {
        private readonly IGuestDayMealJunctionQueryRepository guestDayMealJunctionRepository;

        public GuestDayMealJunctionDetailsQueryHandler(IGuestDayMealJunctionQueryRepository guestDayMealJunctionRepository)
            => this.guestDayMealJunctionRepository = guestDayMealJunctionRepository;

        public async Task<GuestDayMealJunctionDetailsResponseModel?> Handle(
            GuestDayMealJunctionDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.guestDayMealJunctionRepository.Details(
                request.Id,
                cancellationToken);
    }
}