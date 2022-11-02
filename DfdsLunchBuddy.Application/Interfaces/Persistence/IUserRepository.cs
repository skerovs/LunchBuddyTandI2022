using DfdsLunchBuddy.Domain.DomainObjects;

namespace DfdsLunchBuddy.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void UpdateUser(User updatedUser);
    User? GetUserByEmail(string email);
    void Add(User user);
}