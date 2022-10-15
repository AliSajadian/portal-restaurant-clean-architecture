namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.Restaurant.Repositories;
using MediatR;

public class EmployeeDayMealDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class EmployeeDayMealDeleteCommandHandler : IRequestHandler<EmployeeDayMealDeleteCommand, Result>
    {
        private readonly IEmployeeDayMealDomainRepository employeeDayMealRepository;

        public EmployeeDayMealDeleteCommandHandler(IEmployeeDayMealDomainRepository employeeDayMealRepository)
            => this.employeeDayMealRepository = employeeDayMealRepository;

        public async Task<Result> Handle(
            EmployeeDayMealDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.employeeDayMealRepository.Delete(
                request.Id,
                cancellationToken);
    }
}