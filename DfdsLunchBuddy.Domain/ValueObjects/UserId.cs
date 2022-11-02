using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class UserId : ArbitraryId<Guid>
    {
        public UserId(Guid value) : base(value)
        {
            value.Requires(nameof(value)).IsNotEqualTo(Guid.Empty);
        }
    }
}