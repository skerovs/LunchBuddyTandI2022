
using DfdsLunchBuddy.Domain.ValueObjects;
using FluentAssertions;

namespace DfdsLunchBuddy.Domain.UnitTests
{
    public class BuddyMatchTests
    {
        [Fact]
        public void CreateNewBuddyMatch()
        {
            var fakeAvailableSpot1 = CreateFakeAvailableSpot(Guid.Parse("a343647c-502e-4c92-af81-fcd8e1663e7b")); 
            var fakeAvailableSpot2 = CreateFakeAvailableSpot(Guid.Parse("b343647c-502e-4c92-af81-fcd8e1663e7a"));

            var actual = () => BuddyMatch.Create(fakeAvailableSpot1, fakeAvailableSpot2);

            actual.Should().NotThrow();
        }

        [Fact]
        public void CannotCreateMatchIfBothAvailableSpotsAreForTheSameUser()
        {
            var fakeAvailableSpot1 = CreateFakeAvailableSpot(Guid.Parse("a343647c-502e-4c92-af81-fcd8e1663e7b"));
            var fakeAvailableSpot2 = CreateFakeAvailableSpot(Guid.Parse("a343647c-502e-4c92-af81-fcd8e1663e7b"));

            var actual = () => BuddyMatch.Create(fakeAvailableSpot1, fakeAvailableSpot2);

            actual.Should().Throw<Exception>();
        }


        [Fact]
        public void CannotCreateMatchIfAvailableSpot1IsNull() 
        { 
            AvailableLunchSpot fakeAvailableSpot1 = null;
            AvailableLunchSpot fakeAvailableSpot2 = CreateFakeAvailableSpot(Guid.Parse("a343647c-502e-4c92-af81-fcd8e1663e7b"));

            var actual = () => BuddyMatch.Create(fakeAvailableSpot1, fakeAvailableSpot2);

            actual.Should().Throw<Exception>();
        }

        [Fact]
        public void CannotCreateMatchIfAvailableSpot2IsNull()
        {
            AvailableLunchSpot fakeAvailableSpot1 = CreateFakeAvailableSpot(Guid.Parse("a343647c-502e-4c92-af81-fcd8e1663e7b"));
            AvailableLunchSpot fakeAvailableSpot2 = null;

            var actual = () => BuddyMatch.Create(fakeAvailableSpot1, fakeAvailableSpot2);

            actual.Should().Throw<Exception>();
        }

        private AvailableLunchSpot CreateFakeAvailableSpot(Guid userId)
        {
            var fakeCurrentDate = new DateOnly(2022, 11, 8);
            var date = new LunchDate(2022, 11, 9);
            var timeSlot = new TimeSlot(12, 0);

            return new AvailableLunchSpot(new UserId(userId), date, timeSlot, fakeCurrentDate);
        }
    }
}
