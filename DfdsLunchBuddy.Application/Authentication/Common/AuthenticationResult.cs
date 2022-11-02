using DfdsLunchBuddy.Domain.DomainObjects;

namespace DfdsLunchBuddy.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);