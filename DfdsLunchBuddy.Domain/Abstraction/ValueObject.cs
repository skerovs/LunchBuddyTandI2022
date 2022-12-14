using DfdsLunchBuddy.Domain.Common.Extensions;

namespace DfdsLunchBuddy.Domain.Abstraction
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public static bool operator !=(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null)) return !ReferenceEquals(b, null);
            return !a.Equals(b);
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null)) return ReferenceEquals(b, null);
            return a.Equals(b);
        }

        public abstract IEnumerable<object> EqualityComponents();

        public bool Equals(ValueObject other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(other, null)) return false;
            if (GetType() != other.GetType()) return false;
            return EqualityComponents().SequenceEqual(other.EqualityComponents());
        }

        public override bool Equals(object other) => Equals(other as ValueObject);

        public override int GetHashCode() => HashCodeComponents().CombineHashCodes();

        public virtual IEnumerable<object> HashCodeComponents() => EqualityComponents();

        public IEnumerable<object> PrimitiveEqualityComponents()
        {
            foreach (var component in EqualityComponents())
            {
                var valueObject = component as ValueObject;
                if (valueObject == null)
                    yield return component;
                else
                {
                    foreach (var primitiveComponent in valueObject.PrimitiveEqualityComponents())
                        yield return primitiveComponent;
                }
            }
        }
    }
}