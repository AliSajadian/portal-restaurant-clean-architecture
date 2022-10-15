namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.Restaurant.Repositories;
using MediatR;

public class GuestDayMealDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class GuestDayMealDeleteCommandHandler : IRequestHandler<GuestDayMealDeleteCommand, Result>
    {
        private readonly IGuestDayMealDomainRepository guestDayMealRepository;

        public GuestDayMealDeleteCommandHandler(IGuestDayMealDomainRepository guestDayMealRepository)
            => this.guestDayMealRepository = guestDayMealRepository;

        public async Task<Result> Handle(
            GuestDayMealDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.guestDayMealRepository.Delete(
                request.Id,
                cancellationToken);
    }
}