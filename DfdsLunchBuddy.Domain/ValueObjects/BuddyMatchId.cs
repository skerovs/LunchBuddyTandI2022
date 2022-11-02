using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class BuddyMatchId : ArbitraryId<Guid>
    {
        public BuddyMatchId(Guid value) : base(value)
        {
            value.Requires(nameof(value)).IsNotEqualTo(Guid.Empty);
        }
    }
}