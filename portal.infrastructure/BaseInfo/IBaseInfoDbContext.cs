namespace Portal.Infrastructure.BaseInfo;

using Common.Persistence;
using Domain.BaseInfo.Models.Companies;
using Domain.BaseInfo.Models.Departments;
using Domain.BaseInfo.Models.Projects;
using Domain.BaseInfo.Models.JobPositions;
using Domain.BaseInfo.Models.Employees;
using Microsoft.EntityFrameworkCore;

internal interface IBaseInfoDbContext : IDbContext
{
    DbSet<Company> Companies { get; }
    DbSet<Department> Departments { get; }
    DbSet<Project> Projects { get; }
    DbSet<JobPosition> JobPositions { get; }
    DbSet<Employee> Employees { get; }
}