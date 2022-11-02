using Conditions;
using DfdsLunchBuddy.Domain.Abstraction;
using DfdsLunchBuddy.Domain.ValueObjects;

namespace DfdsLunchBuddy.Domain
{
    public class BuddyMatch : DomainEntity
    {
        private BuddyMatch(AvailableLunchSpot buddy1LunchSpot, AvailableLunchSpot buddy2LunchSpot)
        {
            Condition.Requires(buddy1LunchSpot, nameof(buddy1LunchSpot)).IsNotNull($"{nameof(buddy1LunchSpot)} was null");
            Condition.Requires(buddy2LunchSpot, nameof(buddy2LunchSpot)).IsNotNull($"{nameof(buddy2LunchSpot)} was null");
            Condition.Requires(buddy1LunchSpot.UserId, nameof(buddy1LunchSpot)).IsNotEqualTo(buddy2LunchSpot.UserId);

            Id = new BuddyMatchId(Guid.NewGuid());
            Buddy1Id = buddy1LunchSpot.UserId;
            Buddy2Id = buddy2LunchSpot.UserId;
            LunchDate = buddy1LunchSpot.LunchSpotDate;
            TimeSlot = buddy1LunchSpot.LunchTimeSlot;
        }

        public static BuddyMatch Create(AvailableLunchSpot buddy1LunchSpot, AvailableLunchSpot buddy2LunchSpot)
        {
            return new BuddyMatch(buddy1LunchSpot, buddy2LunchSpot);
        }

        public BuddyMatchId Id { get; init; }

        private UserId Buddy1Id { get; init; }
        private UserId Buddy2Id { get; init; }
        
        private LunchDate LunchDate { get; init; }
        private TimeSlot TimeSlot { get; init; }

        public override ComparableValueObject Identity() => Id;
    }
}
