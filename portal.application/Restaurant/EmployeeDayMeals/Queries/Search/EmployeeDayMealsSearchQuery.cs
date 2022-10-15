namespace Portal.Application.Restaurant.EmployeeDayMeals.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Restaurant.Models.EmployeeDayMeals;
using Domain.Restaurant.Specifications.EmployeeDayMeals;
using Domain.Common;
using MediatR;

public class EmployeeDayMealsSearchQuery : IRequest<EmployeeDayMealsSearchResponseModel>
{
    private const int EmployeeDayMealsPerPage = 10;

    public string? Date { get; init; }

    public int Page { get; init; } = 1;

    public class EmployeeDayMealsSearchQueryHandler : IRequestHandler<EmployeeDayMealsSearchQuery, EmployeeDayMealsSearchResponseModel>
    {
        private readonly IEmployeeDayMealQueryRepository employeeDayMealRepository;

        public EmployeeDayMealsSearchQueryHandler(IEmployeeDayMealQueryRepository employeeDayMealRepository)
            => this.employeeDayMealRepository = employeeDayMealRepository;

        public async Task<EmployeeDayMealsSearchResponseModel> Handle(
            EmployeeDayMealsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetEmployeeDayMealSpecification(request);

            var skip = (request.Page - 1) * EmployeeDayMealsPerPage;

            var companiesListing = await this.employeeDayMealRepository.GetEmployeeDayMealsListing(
                specification,
                skip,
                take: EmployeeDayMealsPerPage,
                cancellationToken);

            var totalEmployeeDayMeals = await this.employeeDayMealRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalEmployeeDayMeals / EmployeeDayMealsPerPage);

            return new EmployeeDayMealsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<EmployeeDayMeal> GetEmployeeDayMealSpecification(
            EmployeeDayMealsSearchQuery request)
            => new EmployeeDayMealByDateSpecification(request.Date);
    }
}