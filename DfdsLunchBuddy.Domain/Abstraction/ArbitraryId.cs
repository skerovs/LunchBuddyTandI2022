using System;
using System.Collections.Generic;

namespace DfdsLunchBuddy.Domain.Abstraction
{
    public abstract class ArbitraryId<TId> : ComparableValueObject
    where TId : IComparable
    {
        protected ArbitraryId(TId value)
        {
            Value = value;
        }

        public TId Value { get; }

        public override IEnumerable<IComparable> ComparableComponents()
        {
            yield return Value;
        }

        public override IEnumerable<object> EqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => $"{GetType().Name} [value={Value}]";
    }
}
