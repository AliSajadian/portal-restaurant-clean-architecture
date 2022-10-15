using System.Buffers;
namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Restaurant.Repositories;
using MediatR;
using Portal.Domain.BaseInfo.Repositories;

public class GuestDayMealEditCommand : GuestDayMealCommand<GuestDayMealEditCommand>, IRequest<Result<int>>
{
    public class GuestDayMealEditCommandHandler : IRequestHandler<GuestDayMealEditCommand, Result<int>>
    {
        private readonly IGuestDayMealDomainRepository guestDayMealRepository;
        private readonly IDepartmentDomainRepository departmentRepository;
        private readonly IProjectDomainRepository projectRepository;

        public GuestDayMealEditCommandHandler(
            IDepartmentDomainRepository departmentRepository,
            IProjectDomainRepository projectRepository,
            IGuestDayMealDomainRepository guestDayMealRepository)
            {
                this.departmentRepository = departmentRepository;
                this.projectRepository = projectRepository;
                this.guestDayMealRepository = guestDayMealRepository;
            }


        public async Task<Result<int>> Handle(
            GuestDayMealEditCommand request,
            CancellationToken cancellationToken)
        {
            var department = await this.departmentRepository.Find(
                request.Department,
                cancellationToken);

            if (department is null)
            {
                throw new NotFoundException(nameof(department), request.Department);
            }

            var project = await this.projectRepository.Find(
                request.Project,
                cancellationToken);

            if (project is null)
            {
                throw new NotFoundException(nameof(project), request.Project);
            }

            var guestDayMeal = await this.guestDayMealRepository.Find(
                request.Id,
                cancellationToken);

            if (guestDayMeal is null)
            {
                throw new NotFoundException(nameof(guestDayMeal), request.Id);
            }

            guestDayMeal.UpdateDate(request.Date)
                        .UpdateDescription(request.Description)
                        .UpdateDepartment(department)
                        .UpdateProject(project);

            await this.guestDayMealRepository.Save(guestDayMeal, cancellationToken);

            return guestDayMeal.Id;
        }
    }
}