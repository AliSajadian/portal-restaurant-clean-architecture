namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.Restaurant.Repositories;
using MediatR;

public class GuestDayMealJunctionDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class GuestDayMealJunctionDeleteCommandHandler : IRequestHandler<GuestDayMealJunctionDeleteCommand, Result>
    {
        private readonly IGuestDayMealJunctionDomainRepository guestDayMealRepository;

        public GuestDayMealJunctionDeleteCommandHandler(IGuestDayMealJunctionDomainRepository guestDayMealRepository)
            => this.guestDayMealRepository = guestDayMealRepository;

        public async Task<Result> Handle(
            GuestDayMealJunctionDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.guestDayMealRepository.Delete(
                request.Id,
                cancellationToken);
    }
}