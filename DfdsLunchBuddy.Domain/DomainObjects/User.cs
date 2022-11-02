using DfdsLunchBuddy.Domain.Abstraction;
using DfdsLunchBuddy.Domain.ValueObjects;

namespace DfdsLunchBuddy.Domain.DomainObjects;

public class User : DomainEntity
{
    private User(FullName name, string email)
    {
        Id = new UserId(Guid.NewGuid());
        FullName = name;
        Email = email; 
        _availableLunchSpots = new List<AvailableLunchSpot>();
    }

    public static User CreateNewUser(string firstName, string lastName, string email, Password password)
    {
        var fullName = new FullName(firstName, lastName);
        var newUser = new User(fullName, email);
        newUser.SetUserPassword(password);
        return newUser;
    }

    public UserId Id { get; private set; }
    public string Email { get; private set; }
    public FullName FullName { get; private set; }
    public string Nickname { get; private set; }
    public Password Password { get; private set; }
    public Department WorkingAt { get; private set; }
    public DepartmentTeam IsPartOfTeam { get; private set; }
    public Country LocatedAt { get; private set; }
    public IReadOnlyCollection<AvailableLunchSpot> AvailableLunchDates => _availableLunchSpots;
    private List<AvailableLunchSpot> _availableLunchSpots { get; set; }
    public bool RadyForMatching { get; private set; }

    public override ComparableValueObject Identity() => Id;

    public void IndicateAvailability(List<AvailableLunchSpot> availableLunchSpotsToAdd)
    {
        foreach(var spot in availableLunchSpotsToAdd)
        {
            if(spot.UserId != Id)
            {
                continue;
            }

            var doesSpotExist = IsSpotAlreadyInExistingAvailableLunchSpots(spot);
            if (doesSpotExist == false)
            {
                _availableLunchSpots.Add(spot);
            }
        }
    }

    public void ReadyUpForMatching()
    {
        RadyForMatching = true;
    }

    private bool IsSpotAlreadyInExistingAvailableLunchSpots(AvailableLunchSpot spot)
    {
        return _availableLunchSpots.Contains(spot);
    }

    public void UpdateUserWorkPlace(Department department, DepartmentTeam userTeam)
    {
        IsPartOfTeam = userTeam;
        WorkingAt = department;
    }

    public void UpdateNickname(string nick)
    {
        Nickname = nick;
    }

    private void SetUserPassword(Password password)
    {
        Password = password;
    }
}