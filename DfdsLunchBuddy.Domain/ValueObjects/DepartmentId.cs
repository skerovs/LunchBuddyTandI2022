using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class DepartmentId : ArbitraryId<int>
    {
        public DepartmentId(int value) : base(value)
        {
            value.Requires(nameof(value)).IsNotLessOrEqual(0);
        }
    }
}