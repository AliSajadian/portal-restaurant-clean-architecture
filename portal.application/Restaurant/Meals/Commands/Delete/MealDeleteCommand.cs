namespace Portal.Application.Restaurant.Meals.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.Restaurant.Repositories;
using MediatR;

public class MealDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class MealDeleteCommandHandler : IRequestHandler<MealDeleteCommand, Result>
    {
        private readonly IMealDomainRepository mealRepository;

        public MealDeleteCommandHandler(IMealDomainRepository mealRepository)
            => this.mealRepository = mealRepository;

        public async Task<Result> Handle(
            MealDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.mealRepository.Delete(
                request.Id,
                cancellationToken);
    }
}