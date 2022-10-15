namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Restaurant.Repositories;
using MediatR;
using Portal.Domain.BaseInfo.Repositories;

public class EmployeeDayMealEditCommand : EmployeeDayMealCommand<EmployeeDayMealEditCommand>, IRequest<Result<int>>
{
    public class EmployeeDayMealEditCommandHandler : IRequestHandler<EmployeeDayMealEditCommand, Result<int>>
    {
        private readonly IDayMealDomainRepository dayMealRepository;
        private readonly IEmployeeDayMealDomainRepository employeeDayMealRepository;
        private readonly IEmployeeDomainRepository employeeRepository;

        public EmployeeDayMealEditCommandHandler(
            IEmployeeDomainRepository employeeRepository,
            IDayMealDomainRepository dayMealRepository,
            IEmployeeDayMealDomainRepository employeeDayMealRepository)
            {
                this.employeeRepository = employeeRepository;
                this.dayMealRepository = dayMealRepository;
                this.employeeDayMealRepository = employeeDayMealRepository;
            }


        public async Task<Result<int>> Handle(
            EmployeeDayMealEditCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await this.employeeRepository.Find(
                request.PersonelCode,
                cancellationToken);

            if (employee is null)
            {
                throw new NotFoundException(nameof(employee), request.PersonelCode);
            }

            var dayMeal = await this.dayMealRepository.Find(
                request.DayMealId,
                cancellationToken);

            if (dayMeal is null)
            {
                throw new NotFoundException(nameof(dayMeal), request.DayMealId);
            }

            var employeeDayMeal = await this.employeeDayMealRepository.Find(
                request.Id,
                cancellationToken);

            if (employeeDayMeal is null)
            {
                throw new NotFoundException(nameof(employeeDayMeal), request.Id);
            }

            employeeDayMeal.UpdateServed(request.Served)
                      .UpdateEmployee(employee)
                      .UpdateDayMeal(dayMeal);

            await this.employeeDayMealRepository.Save(employeeDayMeal, cancellationToken);

            return employeeDayMeal.Id;
        }
    }
}