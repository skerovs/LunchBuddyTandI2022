using DfdsLunchBuddy.Common.Errors;
using DfdsLunchBuddy.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DfdsLunchBuddy;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, LunchBuddyProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}
