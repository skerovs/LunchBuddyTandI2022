using FluentAssertions;
using DfdsLunchBuddy.Domain.DomainObjects;
using DfdsLunchBuddy.Domain.ValueObjects;

namespace DfdsLunchBuddy.Domain.UnitTests
{
    public class UserTests
    {
        [Fact]
        public void RegisterAsLunchBuddy()
        {
            Action actual = () => createFakeUser();

            actual.Should().NotThrow<Exception>();
            actual.Should().NotBeNull();
        }

        [Fact]
        public void CanAddDepartmentDetails_DoesNotThrow()
        {
            var user = createFakeUser();
            var fakeDepartment = new Department("T&I");

            Action actual = () => user.UpdateUserWorkPlace(fakeDepartment, null);

            actual.Should().NotThrow<Exception>();
        }

        [Fact]
        public void CanUpdateDepartmentDetails()
        {
            var user = createFakeUser();
            var department = new Department("T&I");

            user.UpdateUserWorkPlace(department, null);

            user.WorkingAt.Name.Should().Be(department.Name);
        }

        [Fact]
        public void CanAddTeamDetails()
        {
            var user = createFakeUser();
            var team = new DepartmentTeam("Awesome team");

            user.UpdateUserWorkPlace(null, team);

            user.IsPartOfTeam.Should().Be(team);
            user.IsPartOfTeam.Name.Should().Be(team.Name);
        }

        [Fact]
        public void AddNewAvailableSpots_AllSpotsAdded_IfSpotsNotAlreadyInColection()
        {
            var user = createFakeUser();
            var fakeCurrentDate = new DateOnly(2022, 3, 20);
            var lunchSpotsToAdd = new List<AvailableLunchSpot>() 
            { 
                AvailableLunchSpot.Create(user.Id, 2022, 3, 25, 12, 0, fakeCurrentDate),
                AvailableLunchSpot.Create(user.Id, 2022, 3, 28, 12, 0, fakeCurrentDate),
                AvailableLunchSpot.Create(user.Id, 2022, 3, 29, 12, 0, fakeCurrentDate),
            };

            user.IndicateAvailability(lunchSpotsToAdd);

            user.AvailableLunchDates.Count.Should().Be(3);
        }

        [Fact]
        public void AddNewAvailableSpots_AddsOnlyOneSpot_IfAllSpotsHaveTheSameValue()
        {
            var user = createFakeUser();
            var fakeCurrentDate = new DateOnly(2022, 3, 20);
            var lunchSpotsToAdd = new List<AvailableLunchSpot>()
            {
                AvailableLunchSpot.Create(user.Id, 2022, 3, 28, 12, 0, fakeCurrentDate),
                AvailableLunchSpot.Create(user.Id, 2022, 3, 28, 12, 0, fakeCurrentDate),
                AvailableLunchSpot.Create(user.Id, 2022, 3, 28, 12, 0, fakeCurrentDate),
            }; 

            user.IndicateAvailability(lunchSpotsToAdd);

            user.AvailableLunchDates.Count.Should().Be(1);
        }

        [Fact]
        public void UserIsReadyToBeMatchedWithABuddy()
        {
            var user = createFakeUser();

            user.ReadyUpForMatching();

            user.RadyForMatching.Should().BeTrue();
        }

        public User createFakeUser()
        {
            return User.CreateNewUser("Monkey", "Skerovs", "t@gmail.com", new Password("dflk23l;a"));
        }
    }
}