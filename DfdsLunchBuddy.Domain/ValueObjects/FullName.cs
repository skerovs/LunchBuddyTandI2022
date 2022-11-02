
using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;
using DfdsLunchBuddy.Domain.Extensions;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class FullName : ComparableValueObject
    {
        public FullName(string lastName, string firstName)
        {
            lastName.Requires(nameof(lastName)).IsNotNullOrWhiteSpace();
            firstName.Requires(nameof(firstName)).IsNotNullOrWhiteSpace();
            LastName = lastName.ToTitleCase();
            FirstName = firstName.ToTitleCase();
        }

        public string FirstName { get; }

        public string LastName { get; }


        public string AsFormattedName() => $"{LastName.ToUpper()} {FirstName}";

        public override IEnumerable<IComparable> ComparableComponents()
        {
            yield return LastName;
            yield return FirstName;
        }

        public override IEnumerable<object> EqualityComponents()
        {
            yield return LastName;
            yield return FirstName;
        }

        //public static FullName FromState(FullNameSnapshot state)
        //{
        //    if (state == null) return null;
        //    return new FullName
        //    (
        //        state.LastName,
        //        state.FirstName
        //    );
        //}

        //public FullNameSnapshot ToSnapshot()
        //{
        //    return new FullNameSnapshot
        //    {
        //        LastName = LastName,
        //        FirstName = FirstName
        //    };
        //}
    }
}