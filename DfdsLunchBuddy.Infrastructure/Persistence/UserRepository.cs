using DfdsLunchBuddy.Application.Common.Interfaces.Persistence;
using DfdsLunchBuddy.Domain.DomainObjects;

namespace DfdsLunchBuddy.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void UpdateUser(User updatedUser)
    {
        var userIndex = _users.FindIndex(u => u.Email == updatedUser.Email);
        _users[userIndex] = updatedUser;
    }
}
