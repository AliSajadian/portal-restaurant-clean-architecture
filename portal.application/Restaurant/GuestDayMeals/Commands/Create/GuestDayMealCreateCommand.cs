namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Common.Exceptions;
using Common;
using Domain.Restaurant.Factories.GuestDayMeals;
using Domain.Restaurant.Repositories;
using MediatR;
using Portal.Domain.BaseInfo.Repositories;

public class GuestDayMealCreateCommand : GuestDayMealCommand<GuestDayMealCreateCommand>, IRequest<Result<int>>
{
    public class GuestDayMealCreateCommandHandler : IRequestHandler<GuestDayMealCreateCommand, Result<int>>
    {
        private readonly IGuestDayMealFactory guestDayMealFactory;
        private readonly IGuestDayMealDomainRepository guestDayMealRepository;
        private readonly IDepartmentDomainRepository departmentRepository;
        private readonly IProjectDomainRepository projectRepository;

        public GuestDayMealCreateCommandHandler(
            IGuestDayMealFactory guestDayMealFactory,
            IDepartmentDomainRepository departmentRepository,
            IProjectDomainRepository projectRepository,
            IGuestDayMealDomainRepository guestDayMealRepository)
        {
            this.guestDayMealFactory = guestDayMealFactory;
            this.departmentRepository = departmentRepository;
            this.projectRepository = projectRepository;
            this.guestDayMealRepository = guestDayMealRepository;
        }

        public async Task<Result<int>> Handle(
            GuestDayMealCreateCommand request,
            CancellationToken cancellationToken)
        {
            var department = await this.departmentRepository.Find(
                request.Department,
                cancellationToken);

            if(department is null)
            {
                throw new NotFoundException(nameof(department), request.Department);
            }    
            
            var project = await this.projectRepository.Find(
                request.Project, 
                cancellationToken);

            if(project is null)
            {
                throw new NotFoundException(nameof(project), request.Project);
            }

            var guestDayMeal = this.guestDayMealFactory
                .WithDate(request.Date)
                .WithDescription(request.Description)
                .FromSection(department, project)
                .Build();

            await this.guestDayMealRepository.Save(guestDayMeal, cancellationToken);

            return guestDayMeal.Id;
        }
    }
}