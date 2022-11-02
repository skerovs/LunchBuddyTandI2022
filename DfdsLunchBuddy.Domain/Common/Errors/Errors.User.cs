using ErrorOr;

namespace DfdsLunchBuddy.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");

        public static Error NotFound => Error.Conflict(
            code: "User.NotFound",
            description: "User with provided email was not found.");
    }
}