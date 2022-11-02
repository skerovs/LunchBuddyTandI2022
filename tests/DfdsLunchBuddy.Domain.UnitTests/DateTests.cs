
using DfdsLunchBuddy.Domain.ValueObjects;
using FluentAssertions;

namespace DfdsLunchBuddy.Domain.UnitTests
{
    public class DateTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        [InlineData(-1)]
        public void CannotCreateDateOutside12Months(int month)
        {
            var actual = () => new LunchDate(2022, month, 1);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(32)]
        [InlineData(-1)]
        public void CannotCreateDateOutside31Days(int day)
        {
            var actual = () => new LunchDate(2022, 1, day);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(2,30)]
        [InlineData(4, 31)]
        [InlineData(6,31)]
        [InlineData(9,31)]
        [InlineData(11,31)]
        public void CannotCreateDateWith31DaysForMonthsWithLowerAmmountOfDays(int month, int day)
        {
            var actual = () => new LunchDate(2022, month, day);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 8)]
        [InlineData(5, 15)]
        public void CannotCreateDateWithWeekendDays(int month, int day)
        {
            var actual = () => new LunchDate(2022, month, day);

            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(11,29)]
        [InlineData(9,20)]
        [InlineData(2,14)]
        public void CreateNewDate(int month, int day)
        {
            var actual = new LunchDate(2022, month, day);

            actual.Should().BeOfType<LunchDate>();
            actual.Month.Should().Be(month);
            actual.Day.Should().Be(day);
        }

        [Theory]
        [InlineData(8, 30, 20)]
        [InlineData(8, 19, 9)]
        [InlineData(8, 12, 2)]
        [InlineData(8, 1, -9)]
        public void HowFarIsLunchDateFromDateTimeNow(int month, int day, int expected)
        {
            var fakeDateTimeNow = DateTime.Parse("2022-08-10T00:00");
            var sut = new LunchDate(2022, month, day);

            var actual = sut.HowFarInFutureIsLunchDateInDays(fakeDateTimeNow);

            actual.Should().Be(expected);
        }
    }
}
