using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;

namespace DfdsLunchBuddy.Domain.ValueObjects
{
    //Thought: Is this Value Object or isit Entity
    public class AvailableLunchSpot : ComparableValueObject
    {
        public AvailableLunchSpot(UserId userId, LunchDate availableDate, TimeSlot timeSlot, DateOnly currentDate)
        {
            currentDate = currentDate == DateOnly.MinValue || currentDate == DateOnly.MaxValue ? DateOnly.FromDateTime(DateTime.Now) : currentDate;
            CheckIfSpotIsNotInThePast(availableDate, currentDate);
            CheckIfSpotIsTooFarInFuture(availableDate, currentDate);
            Condition.Requires(userId, nameof(userId)).IsNotNull($"Available lunch spot requires {userId}");

            LunchSpotDate = availableDate;
            LunchTimeSlot = timeSlot;
            UserId = userId;
        }

        public static AvailableLunchSpot Create(UserId userId, int year, int month, int day, int hour, int minute, DateOnly currentDate)
        {
            var spotDate = new LunchDate(year, month, day);
            var timeSlot = new TimeSlot(hour, minute);

            return new AvailableLunchSpot(userId, spotDate, timeSlot, currentDate);
        }

        public UserId UserId { get; init; }
        public TimeSlot LunchTimeSlot { get; init; }

        public LunchDate LunchSpotDate { get; init; }

        public string GetLunchSpotDateAndTime()
        {
            return $"{LunchSpotDate.ToString()} {LunchTimeSlot.ToString()}";
        }

        private void CheckIfSpotIsNotInThePast(LunchDate availableDate, DateOnly currentDate)
        {
            var numberOfDaysInPast = availableDate.HowFarInFutureIsLunchDateInDays(currentDate.ToDateTime(TimeOnly.MinValue)) ;
            Condition.WithExceptionOnFailure<ArgumentOutOfRangeException>().Requires(numberOfDaysInPast, nameof(numberOfDaysInPast))
                     .IsNotLessThan(0, $"Lunch spot cannot be created in the past");
        }

        private void CheckIfSpotIsTooFarInFuture(LunchDate availableDate, DateOnly currentDate)
        {
            var numberOfDaysInFuture = availableDate.HowFarInFutureIsLunchDateInDays(currentDate.ToDateTime(TimeOnly.MinValue));
            Condition.WithExceptionOnFailure<ArgumentOutOfRangeException>().Requires(numberOfDaysInFuture, nameof(numberOfDaysInFuture))
                     .IsNotGreaterThan(14, $"Lunch spot cannot be created more than 14 days in the future");
        }

        public override IEnumerable<IComparable> ComparableComponents()
        {
            yield return LunchSpotDate;
            yield return LunchTimeSlot;
        }

        public override IEnumerable<object> EqualityComponents()
        {
            yield return LunchSpotDate;
            yield return LunchTimeSlot;
        }
    }
}
