namespace Portal.Infrastructure;

using System.Text;
using Application.Common;
using Application.Common.Contracts;
using Application.Identity;
using Common.Events;
using Common.Extensions;
using Common.Persistence;
using Common.Services;
using Domain.Common;
using Identity;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Portal.Infrastructure.BaseInfo;
using Portal.Infrastructure.Restaurant;
using StackExchange.Redis;

using static Domain.Common.Models.ModelConstants.Identity;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddRepositories()
            .AddIdentity(configuration)
            .AddTransient<IEventDispatcher, EventDispatcher>();

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<PortalDbContext>(options => options
                .UseSqlServer(
                    configuration.GetDefaultConnectionString(),
                    sqlServer => sqlServer.MigrationsAssembly(
                        typeof(PortalDbContext).Assembly.FullName)))
            .AddScoped<IBaseInfoDbContext>(provider => provider
                .GetService<PortalDbContext>()!)
            .AddScoped<IRestaurantDbContext>(provider => provider
                .GetService<PortalDbContext>()!)
            .AddTransient<IDbInitializer, PortalDbInitializer>();

    private static IServiceCollection AddMemoryDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(
                    configuration.GetRedisConnectionString()))
            .AddTransient<IMemoryDatabase, MemoryDatabase>();

    internal static IServiceCollection AddRepositories(
        this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IDomainRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime())
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IQueryRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

    private static IServiceCollection AddIdentity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddTransient<IIdentity, IdentityService>()
            .AddTransient<IJwtGenerator, JwtGeneratorService>()
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = MinPasswordLength;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<PortalDbContext>();

        var secret = configuration
            .GetSection(nameof(ApplicationSettings))
            .GetValue<string>(nameof(ApplicationSettings.Secret));

        var key = Encoding.ASCII.GetBytes(secret);

        services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
}