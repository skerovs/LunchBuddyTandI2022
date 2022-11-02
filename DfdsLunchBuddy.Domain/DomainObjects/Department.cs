using Conditions;
using Dfds.Logistics.Packaging.Manager.Domain.Abstrations;
using DfdsLunchBuddy.Domain.Abstraction;
using DfdsLunchBuddy.Domain.Extensions;
using DfdsLunchBuddy.Domain.Snapshots;
using DfdsLunchBuddy.Domain.ValueObjects;

namespace DfdsLunchBuddy.Domain.DomainObjects
{
    public class Department : DomainEntity, IStateObjectConvertible<DepartmentSnapshot>
    {
        public Department(string departmentName)
        {
            departmentName.Requires(nameof(departmentName)).IsNotNullOrWhiteSpace();

            Name = departmentName.ToTitleCase();
        }

        public DepartmentId Id { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }


        public override ComparableValueObject Identity() => Id;

        public static Department Restore(DepartmentSnapshot snapshot)
        {
            var department = new Department(snapshot.Name);
            department.Id = new DepartmentId(snapshot.Id);
            department.ShortName = snapshot.ShortName;
            return department;
        }

        public DepartmentSnapshot ToSnapshot()
        {
            return new DepartmentSnapshot
            {
                Id = Id.Value,
                Name = Name,
                ShortName = ShortName
            };
        }
    }
}
