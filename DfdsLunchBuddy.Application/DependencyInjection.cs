using System.Reflection;
using DfdsLunchBuddy.Application.Authentication.Commands.Register;
using DfdsLunchBuddy.Application.Authentication.Queries.Login;
using DfdsLunchBuddy.Application.Buddy.Commands;
using DfdsLunchBuddy.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DfdsLunchBuddy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddScoped(typeof(IValidator<RegisterUserCommand>), typeof(RegisterUserCommandValidator));
        services.AddScoped(typeof(IValidator<LoginQuery>), typeof(LoginQueryValidator));
        services.AddScoped(typeof(IValidator<UpdateUserWorkPlaceCommand>), typeof(UpdateUserWorkPlaceCommandValidator));

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        return services;
    }
}
