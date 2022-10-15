namespace Portal.Infrastructure.BaseInfo.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BaseInfo.Companies;
using Application.BaseInfo.Companies.Queries.Common;
using Application.BaseInfo.Companies.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.BaseInfo.Models.Companies;
using Domain.BaseInfo.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class CompanyRepository : DataRepository<IBaseInfoDbContext, Company>,
    ICompanyDomainRepository,
    ICompanyQueryRepository
{
    public CompanyRepository(
        IBaseInfoDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Company?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Company?> Find(
        string name,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Name == name)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var company = await this.Data.Companies.FindAsync(id);

        if (company is null)
        {
            return false;
        }

        this.Data.Companies.Remove(company);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<CompanyDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<CompanyDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Company> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetCompaniesQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<CompanyResponseModel>> GetCompaniesListing(
        Specification<Company> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<CompanyResponseModel>(this
                .GetCompaniesQuery(specification)
                .OrderBy(a => a.Name)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Company> GetCompaniesQuery(
        Specification<Company> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}