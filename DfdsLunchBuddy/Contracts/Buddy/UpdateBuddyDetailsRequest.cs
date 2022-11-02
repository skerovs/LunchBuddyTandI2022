namespace DfdsLunchBuddy.Contracts.Authentication;

public record UpdateBuddyDetailsRequest(
    Guid Id,
    string FirstName,
    string LastName,
    string Email);