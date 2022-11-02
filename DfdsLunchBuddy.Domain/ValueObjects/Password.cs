using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;
using DfdsLunchBuddy.Domain.Exceptions;
using ErrorOr;
using System.Security.Cryptography;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public Password(string passwordValue)
        {
            Condition.Requires(passwordValue, nameof(passwordValue))
              .IsNotNull($"{nameof(Password)} was not provided");

            Condition.Requires(passwordValue.Length, nameof(passwordValue))
              .IsGreaterThan(6, $"Provided {nameof(Password)} was too short");

            _passwordHash = EncryptPassword(passwordValue);
        }

        private string _passwordHash;

        public override IEnumerable<IComparable> EqualityComponents()
        {
            yield return _passwordHash;
        }

        public bool IsPasswordMatching(string password)
        {
            var passwordToCompare = new Password(password);
            return this == passwordToCompare;
        }

        private string EncryptPassword(string passwordValue)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(passwordValue);
            data = new SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}
