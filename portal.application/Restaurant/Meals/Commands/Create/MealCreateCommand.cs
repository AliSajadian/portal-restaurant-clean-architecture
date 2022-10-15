namespace Portal.Application.Restaurant.Meals.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Common;
using Domain.Restaurant.Factories.Meals;
using Domain.Restaurant.Repositories;
using MediatR;

public class MealCreateCommand : MealCommand<MealCreateCommand>, IRequest<Result<int>>
{
    public class MealCreateCommandHandler : IRequestHandler<MealCreateCommand, Result<int>>
    {
        private readonly IMealFactory mealFactory;
        private readonly IMealDomainRepository mealRepository;

        public MealCreateCommandHandler(
            IMealFactory mealFactory,
            IMealDomainRepository mealRepository)
        {
            this.mealFactory = mealFactory;
            this.mealRepository = mealRepository;
        }

        public async Task<Result<int>> Handle(
            MealCreateCommand request,
            CancellationToken cancellationToken)
        {
            var meal = this.mealFactory
                .WithName(request.Name)
                .Build();

            await this.mealRepository.Save(meal, cancellationToken);

            return meal.Id;
        }
    }
}