using DfdsLunchBuddy.Domain.DomainObjects;

namespace DfdsLunchBuddy.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}