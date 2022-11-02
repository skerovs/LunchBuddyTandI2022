using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;
using DfdsLunchBuddy.Domain.Exceptions;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    public class TimeSlot : ComparableValueObject
    {
        public readonly int Hour;
        public readonly int Minute;
        public readonly int StartTime;
        private readonly int durationInMinutes = 30;

        public TimeSlot(int hour, int minute)
        {
            Condition.WithExceptionOnFailure<TimeInputWasOutOfCanteineHours>()
                     .Requires(hour, nameof(hour))
                     .IsGreaterOrEqual(11)
                     .IsLessOrEqual(13, $"{nameof(hour)} input was out of valid values");


            Condition.WithExceptionOnFailure<TimeInputWasOutOfCanteineHours>()
                     .Requires(minute, nameof(minute))
                     .IsGreaterOrEqual(0)
                     .IsLessOrEqual(59, $"{nameof(minute)} input was out of valid values");

            if (hour == 11 && minute < 30)
            {
                throw new TimeInputWasOutOfCanteineHours($"The earliest possible time is 11:30");
            }

            Hour = hour;
            Minute = minute;
        }

        public override IEnumerable<IComparable> ComparableComponents()
        {
            yield return Hour;
            yield return Minute;
        }

        public override IEnumerable<object> EqualityComponents()
        {
            yield return Hour;
            yield return Minute;
        }
        
        public override string ToString()
        {
            return $"{Hour}:{Minute:00}";
        }

        public static TimeSlot From(DateTime dateTime) => new TimeSlot(dateTime.Hour, dateTime.Minute);
    }
}