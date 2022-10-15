namespace Portal.Application.Restaurant.DayMeals.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.Restaurant.Repositories;
using MediatR;

public class DayMealDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class DayMealDeleteCommandHandler : IRequestHandler<DayMealDeleteCommand, Result>
    {
        private readonly IDayMealDomainRepository dayMealRepository;

        public DayMealDeleteCommandHandler(IDayMealDomainRepository dayMealRepository)
            => this.dayMealRepository = dayMealRepository;

        public async Task<Result> Handle(
            DayMealDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.dayMealRepository.Delete(
                request.Id,
                cancellationToken);
    }
}