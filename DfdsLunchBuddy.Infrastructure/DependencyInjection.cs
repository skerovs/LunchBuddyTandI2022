using DfdsLunchBuddy.Application.Common.Interfaces.Authentication;
using DfdsLunchBuddy.Application.Common.Interfaces.Persistence;
using DfdsLunchBuddy.Application.Common.Interfaces.Services;
using DfdsLunchBuddy.Infrastructure.Authentication;
using DfdsLunchBuddy.Infrastructure.Persistence;
using DfdsLunchBuddy.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DfdsLunchBuddy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }
}
