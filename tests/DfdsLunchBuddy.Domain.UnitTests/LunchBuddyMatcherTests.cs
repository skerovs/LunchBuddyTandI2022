
using DfdsLunchBuddy.Domain.DomainObjects;
using DfdsLunchBuddy.Domain.Services;
using DfdsLunchBuddy.Domain.ValueObjects;

namespace DfdsLunchBuddy.Domain.UnitTests
{
    public class LunchBuddyMatcherTests
    {
        [Fact]
        public void GetsCollectionOfAvailableSpotsWhichAreInSpanOff15Min()
        {
            //Arrange
            var user1 = CreateTestUser("Alfa");
            user1.IndicateAvailability(new List<AvailableLunchSpot>()
            {
                CreateAvailableLunchSpots(user1.Id, 8, 10),
                CreateAvailableLunchSpots(user1.Id, 8, 11)
            });

            var user2 = CreateTestUser("Beta");
            user1.IndicateAvailability(new List<AvailableLunchSpot>()
            {
                CreateAvailableLunchSpots(user2.Id, 8, 10),
                CreateAvailableLunchSpots(user2.Id, 8, 15)
            });

            var testUsers = new List<User>() { user1, user2};

            var sut = new LunchBuddyMatcher(testUsers);

            //Act


            //Assert

        }

        private User CreateTestUser(string name)
        {
            return User.CreateNewUser(name, name, "t@gmail.com", new Password("dflk23l;a"));
        }

        private AvailableLunchSpot CreateAvailableLunchSpots(UserId userId, int month, int day)
        {
            return AvailableLunchSpot.Create(userId, 2022, month, day, 12, 0, new DateOnly(2022, 8, 8));
        }
    }
}
