namespace Portal.Application.Restaurant.DayMeals.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Common.Exceptions;
using Common;
using Domain.Restaurant.Factories.DayMeals;
using Domain.Restaurant.Repositories;
using MediatR;

public class DayMealCreateCommand : DayMealCommand<DayMealCreateCommand>, IRequest<Result<int>>
{
    public class DayMealCreateCommandHandler : IRequestHandler<DayMealCreateCommand, Result<int>>
    {
        private readonly IDayMealFactory dayMealFactory;
        private readonly IDayMealDomainRepository dayMealRepository;
        private readonly IMealDomainRepository mealRepository;

        public DayMealCreateCommandHandler(
            IDayMealFactory dayMealFactory,
            IMealDomainRepository mealRepository,
            IDayMealDomainRepository dayMealRepository)
        {
            this.dayMealFactory = dayMealFactory;
            this.mealRepository = mealRepository;
            this.dayMealRepository = dayMealRepository;
        }

        public async Task<Result<int>> Handle(
            DayMealCreateCommand request,
            CancellationToken cancellationToken)
        {
            var meal = await this.mealRepository.Find(
                request.Meal, 
                cancellationToken);

            if(meal == null)
            {
                throw new NotFoundException(nameof(meal), request.Meal);
            }

            var dayMeal = this.dayMealFactory
                .WithDate(request.Date)
                .FromMeal(meal)
                .Build();

            await this.dayMealRepository.Save(dayMeal, cancellationToken);

            return dayMeal.Id;
        }
    }
}