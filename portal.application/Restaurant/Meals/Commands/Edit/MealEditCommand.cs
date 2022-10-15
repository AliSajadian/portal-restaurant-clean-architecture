namespace Portal.Application.Restaurant.Meals.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Restaurant.Repositories;
using MediatR;

public class MealEditCommand : MealCommand<MealEditCommand>, IRequest<Result<int>>
{
    public class MealEditCommandHandler : IRequestHandler<MealEditCommand, Result<int>>
    {
        private readonly IMealDomainRepository mealRepository;

        public MealEditCommandHandler(IMealDomainRepository mealRepository)
            => this.mealRepository = mealRepository;

        public async Task<Result<int>> Handle(
            MealEditCommand request,
            CancellationToken cancellationToken)
        {
            var meal = await this.mealRepository.Find(
                request.Id,
                cancellationToken);

            if (meal is null)
            {
                throw new NotFoundException(nameof(meal), request.Id);
            }

            meal.UpdateName(request.Name);

            await this.mealRepository.Save(meal, cancellationToken);

            return meal.Id;
        }
    }
}