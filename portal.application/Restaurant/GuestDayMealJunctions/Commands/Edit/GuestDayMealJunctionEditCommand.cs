using System.Buffers;
namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Restaurant.Repositories;
using MediatR;
using Portal.Domain.BaseInfo.Repositories;

public class GuestDayMealJunctionEditCommand : GuestDayMealJunctionCommand<GuestDayMealJunctionEditCommand>, IRequest<Result<int>>
{
    public class GuestDayMealJunctionEditCommandHandler : IRequestHandler<GuestDayMealJunctionEditCommand, Result<int>>
    {
        private readonly IGuestDayMealJunctionDomainRepository guestDayMealJunctionRepository;
        private readonly IGuestDayMealDomainRepository guestDayMealRepository;
        private readonly IDayMealDomainRepository dayMealRepository;

        public GuestDayMealJunctionEditCommandHandler(
            IGuestDayMealDomainRepository guestDayMealRepository,
            IDayMealDomainRepository dayMealRepository,
            IGuestDayMealJunctionDomainRepository guestDayMealJunctionRepository)
            {
                this.guestDayMealRepository = guestDayMealRepository;
                this.dayMealRepository = dayMealRepository;
                this.guestDayMealJunctionRepository = guestDayMealJunctionRepository;
            }


        public async Task<Result<int>> Handle(
            GuestDayMealJunctionEditCommand request,
            CancellationToken cancellationToken)
        {
            var dayMeal = await this.dayMealRepository.Find(
                request.DayMealId,
                cancellationToken);

            if (dayMeal is null)
            {
                throw new NotFoundException(nameof(dayMeal), request.DayMealId);
            }

            var guestDayMeal = await this.guestDayMealRepository.Find(
                request.GuestDayMealId,
                cancellationToken);

            if (guestDayMeal is null)
            {
                throw new NotFoundException(nameof(guestDayMeal), request.GuestDayMealId);
            }

            var guestDayMealJunction = await this.guestDayMealJunctionRepository.Find(
                request.Id,
                cancellationToken);

            if (guestDayMealJunction is null)
            {
                throw new NotFoundException(nameof(guestDayMealJunction), request.Id);
            }

            guestDayMealJunction.UpdateQty(request.Qty)
                        .UpdateDayMeal(dayMeal)
                        .UpdateGuestDayMeal(guestDayMeal);

            await this.guestDayMealJunctionRepository.Save(guestDayMealJunction, cancellationToken);

            return guestDayMealJunction.Id;
        }
    }
}