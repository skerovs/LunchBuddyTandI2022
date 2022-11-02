

namespace DfdsLunchBuddy.Domain.Abstraction
{
    /// <summary>
    /// Base class for entities of the Domain Model.
    /// </summary>
    public abstract class DomainEntity : IEquatable<DomainEntity>
    {
        protected DomainEntity() { }


        public static bool operator !=(DomainEntity a, DomainEntity b)
        {
            if (ReferenceEquals(a, null)) return !ReferenceEquals(b, null);
            return !a.Equals(b);
        }

        public static bool operator ==(DomainEntity a, DomainEntity b)
        {
            if (ReferenceEquals(a, null)) return ReferenceEquals(b, null);
            return a.Equals(b);
        }


        public bool Equals(DomainEntity other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(other, null)) return false;
            if (GetType() != other.GetType()) return false;
            return Identity().Equals(other.Identity());
        }

        public override bool Equals(object other) => Equals(other as DomainEntity);

        public override int GetHashCode() => Identity().GetHashCode();

        public virtual string IdentityAsString()
        {
            return string.Join("/", Identity().PrimitiveEqualityComponents());
        }

        public abstract ComparableValueObject Identity();
    }
}