using Conditions;
using DfdsLunchBuddy.Domain.DomainObjects;

namespace DfdsLunchBuddy.Domain.Services
{
    public class LunchBuddyMatcher
    {
        public LunchBuddyMatcher(List<User> allUsers)
        {
            Condition.Requires(allUsers, nameof(allUsers)).IsNotNull();
            buddiesReadyToBeMatched = allUsers.Where(u => u.RadyForMatching).ToList();
        }

        private List<User> buddiesReadyToBeMatched { get; set; }
    }
}