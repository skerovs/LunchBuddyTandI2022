using DfdsLunchBuddy.Domain.Abstraction;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class DepartmentTeam : ComparableValueObject
    {
        public DepartmentTeam(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override IEnumerable<IComparable> ComparableComponents()
        {
            yield return Name;
        }

        public override IEnumerable<object> EqualityComponents()
        {
            yield return Name;
        }
    }
}
