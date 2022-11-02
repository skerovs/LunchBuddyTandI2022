using DfdsLunchBuddy.Domain.Exceptions;
using DfdsLunchBuddy.Domain.ValueObjects;
using FluentAssertions;

namespace DfdsLunchBuddy.Domain.UnitTests
{
    public class TimeSlotTests
    {
        [Theory]
        [InlineData(11, 30)]
        [InlineData(12, 0)]
        [InlineData(13, 15)]
        [InlineData(13, 59)]
        public void CreateLunchTimeSlot(int hour, int minute)
        {
            var actual = () => new TimeSlot(hour, minute);

            actual.Should().NotThrow();
        }

        [Theory]
        [InlineData(6, 25)]
        [InlineData(8, 30)]
        [InlineData(10, 30)]
        [InlineData(23, 45)]
        [InlineData(11, 15)]
        [InlineData(14, 0)]
        public void LunchTimeSlotCannotBeOutsideCantineOpenningTimes(int hour, int minute)
        {
            var actual = () => new TimeSlot(hour, minute);

            actual.Should().Throw<DomainException>();
        }

        [Theory]
        [InlineData(11, 30)]
        [InlineData(12, 0)]
        [InlineData(13, 15)]
        [InlineData(13, 05)]
        public void ReturnLunchTimeSlotAsString(int hour, int minute)
        {
            var sut = new TimeSlot(hour, minute);

            var actual = sut.ToString();

            actual.Should().Be($"{hour}:{minute:00}");
        }
    }
}
