
using DfdsLunchBuddy.Application.Authentication.Commands.Register;
using DfdsLunchBuddy.Application.Authentication.Common;
using DfdsLunchBuddy.Application.Authentication.Queries.Login;
using DfdsLunchBuddy.Application.Buddy.Commands;
using DfdsLunchBuddy.Contracts.Authentication;
using Mapster;

namespace DfdsLunchBuddy.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterUserCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.FirstName, src => src.User.FullName.FirstName)
            .Map(dest => dest.LastName, src => src.User.FullName.LastName)
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.Token, src => src.Token);
    }
}