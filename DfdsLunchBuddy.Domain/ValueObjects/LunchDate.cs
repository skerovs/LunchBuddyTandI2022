using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class LunchDate : ComparableValueObject
    {
        public LunchDate(int year, int month, int day)
        {
            var date = new DateOnly(year, month, day);
            
            Condition.WithExceptionOnFailure<ArgumentOutOfRangeException>().Requires(date.DayOfWeek, nameof(date.DayOfWeek))
                     .IsNotEqualTo(DayOfWeek.Saturday)
                     .IsNotEqualTo(DayOfWeek.Sunday, $"{nameof(LunchDate)} cannot be created for Weekend");
            
            Year = year;
            Month = month;
            Day = day;
        }

        public int Year { get; init; }
        public int Month { get; init; }

        public int Day { get; init; }

        public double HowFarInFutureIsLunchDateInDays(DateTime dateTimeNow)
        {
            var differenceBetweenDates = ToDateTime() - dateTimeNow;
            return differenceBetweenDates.TotalDays;
        }

        private DateTime ToDateTime() => new DateTime(Year, Month, Day);

        public override string ToString()
        {
            return $"{Day}.{Month}.";
        }

        public override IEnumerable<IComparable> ComparableComponents()
        {
            yield return Month;
            yield return Day;
        }

        public override IEnumerable<object> EqualityComponents()
        {
            yield return Month;
            yield return Day;
        }
    }
}