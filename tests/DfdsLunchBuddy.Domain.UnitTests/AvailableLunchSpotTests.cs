
using DfdsLunchBuddy.Domain.ValueObjects;
using FluentAssertions;

namespace DfdsLunchBuddy.Domain.UnitTests
{
    public class AvailableLunchSpotTests
    {
        private readonly UserId _fakeUserId = new UserId(Guid.Parse("a343647c-502e-4c92-af81-fcd8e1663e7b"));

        [Fact]
        public void CreateNewAvailableLunchSpot()
        {
            var fakeCurrentDate = new DateOnly(2022, 11, 8);
            var date = new LunchDate(2022, 11, 9);
            var timeSlot = new TimeSlot(12,0);

            var actual = () => new AvailableLunchSpot(_fakeUserId, date, timeSlot, fakeCurrentDate);

            actual.Should().NotThrow<Exception>();
        }

        [Fact]
        public void LunchSpotRequireToHaveUserLikedToItForMatching()
        {
            var fakeCurrentDate = new DateOnly(2022, 11, 8);
            var actual = () => AvailableLunchSpot.Create(null, 2022, 6, 31, 12, 0, fakeCurrentDate);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void LunchSpotCannotBeAtTheWeekend()
        {
            var fakeCurrentDate = new DateOnly(2022, 11, 8);
            var actual = () => AvailableLunchSpot.Create(_fakeUserId, 2022, 6, 31, 12, 0, fakeCurrentDate);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(9, 11)]
        [InlineData(11, 7)]
        [InlineData(11, 2)]
        public void CannotCreateLunchSpotInThePast(int month, int day)
        {
            var fakeCurrentDate = new DateOnly(2022, 11, 8);
            var actual = () => AvailableLunchSpot.Create(_fakeUserId, 2022, month, day, 12, 0, fakeCurrentDate);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(11, 25)]
        [InlineData(12, 11)]
        [InlineData(12, 3)]
        public void CannotCreateLunchSpotMoreThan14DaysInFuture(int month, int day)
        {
            var fakeCurrentDate = new DateOnly(2022, 11, 2);
            var actual = () => AvailableLunchSpot.Create(_fakeUserId, 2022, month, day, 12, 0, fakeCurrentDate);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetLunchSpotDateAndTime()
        {
            var lunchSpot = AvailableLunchSpot.Create(_fakeUserId, 2022, 8, 22, 12, 0, new DateOnly(2022, 8, 8));

            var actual = lunchSpot.GetLunchSpotDateAndTime();

            actual.Should().Be("22.8. 12:00");
        }

        [Theory]
        [InlineData(11, 11, 12, 0)]
        [InlineData(11, 1, 12, 0)]
        [InlineData(11, 2, 11, 30)]
        public void TwoLunchSpotsAreEqualWhenUsingEquality_IfSameValues(int month, int day, int hour, int minute)
        {
            var fakeCurrentDate = new DateOnly(2022, 10, 30);
            var lunchSpot1 = AvailableLunchSpot.Create(_fakeUserId, 2022, month, day, hour, minute, fakeCurrentDate);
            var lunchSpo2 = AvailableLunchSpot.Create(_fakeUserId, 2022, month, day, hour, minute, fakeCurrentDate);

            var actual = lunchSpot1 == lunchSpo2;

            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData(8, 29, 12, 2)]
        [InlineData(8, 29, 13, 0)]
        [InlineData(8, 24, 12, 0)]
        [InlineData(8, 17, 11, 30)]
        [InlineData(8, 16, 12, 15)]
        public void LunchSpot2IsAfterIsAfterSpot1(int month, int day, int hour, int minute)
        {
            var fakeCurrentDate =  new DateOnly(2022, 8, 15);
            var lunchSpot1 = AvailableLunchSpot.Create(_fakeUserId, 2022, 8, 16, 12, 0, fakeCurrentDate);
            var lunchSpo2 = AvailableLunchSpot.Create(_fakeUserId, 2022, month, day, hour, minute, fakeCurrentDate);

            var actual = lunchSpot1 < lunchSpo2;

            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData(10, 21, 12, 0)]
        [InlineData(11, 1, 12, 0)]
        [InlineData(11, 2, 11, 30)]
        public void TwoLunchSpotsAreNotTheSame_IfOneOfTheObjectsIsNull(int month, int day, int hour, int minute)
        {
            var fakeCurrentDate = new DateOnly(2022, 10, 20);
            var lunchSpot1 = AvailableLunchSpot.Create(_fakeUserId, 2022, month, day, hour, minute, fakeCurrentDate);

            var actual = lunchSpot1.CompareTo(null);

            actual.Should().Be(1);
        }
    }
}
