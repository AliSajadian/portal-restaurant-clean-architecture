namespace Portal.Application.Restaurant.DayMeals.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Restaurant.Repositories;
using MediatR;

public class DayMealEditCommand : DayMealCommand<DayMealEditCommand>, IRequest<Result<int>>
{
    public class DayMealEditCommandHandler : IRequestHandler<DayMealEditCommand, Result<int>>
    {
        private readonly IMealDomainRepository dayMealRepository;
        private readonly IDayMealDomainRepository dayDayMealRepository;

        public DayMealEditCommandHandler(
            IMealDomainRepository dayMealRepository,
            IDayMealDomainRepository dayDayMealRepository)
            {
                this.dayMealRepository = dayMealRepository;
                this.dayDayMealRepository = dayDayMealRepository;
            }


        public async Task<Result<int>> Handle(
            DayMealEditCommand request,
            CancellationToken cancellationToken)
        {
            var meal = await this.dayMealRepository.Find(
                request.Meal,
                cancellationToken);

            if (meal is null)
            {
                throw new NotFoundException(nameof(meal), request.Meal);
            }

            var dayDayMeal = await this.dayDayMealRepository.Find(
                request.Id,
                cancellationToken);

            if (dayDayMeal is null)
            {
                throw new NotFoundException(nameof(dayDayMeal), request.Id);
            }

            dayDayMeal.UpdateDate(request.Date)
                      .UpdateTotalNo(request.TotalNo)
                      .UpdateIsActive(request.IsActive)
                      .UpdateMeal(meal);

            await this.dayDayMealRepository.Save(dayDayMeal, cancellationToken);

            return dayDayMeal.Id;
        }
    }
}