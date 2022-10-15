namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Common.Exceptions;
using Common;
using Domain.Restaurant.Factories.GuestDayMealJunctions;
using Domain.Restaurant.Repositories;
using MediatR;
using Portal.Domain.BaseInfo.Repositories;

public class GuestDayMealJunctionCreateCommand : GuestDayMealJunctionCommand<GuestDayMealJunctionCreateCommand>, IRequest<Result<int>>
{
    public class GuestDayMealJunctionCreateCommandHandler : IRequestHandler<GuestDayMealJunctionCreateCommand, Result<int>>
    {
        private readonly IGuestDayMealJunctionsFactory guestDayMealJunctionFactory;
        private readonly IGuestDayMealJunctionDomainRepository guestDayMealJunctionRepository;
        private readonly IGuestDayMealDomainRepository guestDayMealRepository;
        private readonly IDayMealDomainRepository dayMealRepository;

        public GuestDayMealJunctionCreateCommandHandler(
            IGuestDayMealJunctionsFactory guestDayMealJunctionFactory,
            IDayMealDomainRepository dayMealRepository,
            IGuestDayMealDomainRepository guestDayMealRepository,
            IGuestDayMealJunctionDomainRepository guestDayMealJunctionRepository)
        {
            this.guestDayMealJunctionFactory = guestDayMealJunctionFactory;
            this.dayMealRepository = dayMealRepository;
            this.guestDayMealRepository = guestDayMealRepository;
            this.guestDayMealJunctionRepository = guestDayMealJunctionRepository;
        }

        public async Task<Result<int>> Handle(
            GuestDayMealJunctionCreateCommand request,
            CancellationToken cancellationToken)
        {
            var dayMeal = await this.dayMealRepository.Find(
                request.DayMealId,
                cancellationToken);

            if(dayMeal is null)
            {
                throw new NotFoundException(nameof(dayMeal), request.DayMealId);
            }    
            
            var guestDayMeal = await this.guestDayMealRepository.Find(
                request.GuestDayMealId, 
                cancellationToken);

            if(guestDayMeal is null)
            {
                throw new NotFoundException(nameof(guestDayMeal), request.GuestDayMealId);
            }

            var guestDayMealJunction = this.guestDayMealJunctionFactory
                .WithQty(request.Qty)
                .FromDayMeal(dayMeal)
                .FromGuestDayMeal(guestDayMeal)
                .Build();

            await this.guestDayMealJunctionRepository.Save(guestDayMealJunction, cancellationToken);

            return guestDayMealJunction.Id;
        }
    }
}