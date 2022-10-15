namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Common.Exceptions;
using Common;
using Domain.Restaurant.Factories.EmployeeDayMeals;
using Domain.Restaurant.Repositories;
using MediatR;
using Portal.Domain.BaseInfo.Repositories;

public class EmployeeDayMealCreateCommand : EmployeeDayMealCommand<EmployeeDayMealCreateCommand>, IRequest<Result<int>>
{
    public class EmployeeDayMealCreateCommandHandler : IRequestHandler<EmployeeDayMealCreateCommand, Result<int>>
    {
        private readonly IEmployeeDayMealFactory employeeDayMealFactory;
        private readonly IEmployeeDayMealDomainRepository employeeDayMealRepository;
        private readonly IEmployeeDomainRepository employeeRepository;
        private readonly IDayMealDomainRepository dayMealRepository;

        public EmployeeDayMealCreateCommandHandler(
            IEmployeeDayMealFactory employeeDayMealFactory,
            IEmployeeDomainRepository employeeRepository,
            IDayMealDomainRepository dayMealRepository,
            IEmployeeDayMealDomainRepository employeeDayMealRepository)
        {
            this.employeeDayMealFactory = employeeDayMealFactory;
            this.employeeRepository = employeeRepository;
            this.dayMealRepository = dayMealRepository;
            this.employeeDayMealRepository = employeeDayMealRepository;
        }

        public async Task<Result<int>> Handle(
            EmployeeDayMealCreateCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await this.employeeRepository.Find(
                request.PersonelCode,
                cancellationToken);

            if(employee is null)
            {
                throw new NotFoundException(nameof(employee), request.PersonelCode);
            }    
            
            var dayMeal = await this.dayMealRepository.Find(
                request.DayMealId, 
                cancellationToken);

            if(dayMeal is null)
            {
                throw new NotFoundException(nameof(dayMeal), request.DayMealId);
            }

            var employeeDayMeal = this.employeeDayMealFactory
                .WithServed(request.Served)
                .FromEmployee(employee)
                .FromDayMeal(dayMeal)
                .Build();

            await this.employeeDayMealRepository.Save(employeeDayMeal, cancellationToken);

            return employeeDayMeal.Id;
        }
    }
}