using DfdsLunchBuddy.Application.Common.Interfaces.Persistence;
using DfdsLunchBuddy.Domain.DomainObjects;
using DfdsLunchBuddy.Domain.Snapshots;

namespace DfdsLunchBuddy.Infrastructure.Persistence;

public class DepartmentRepository : IDepartmentRepository
{
    private static readonly List<DepartmentSnapshot> _snapshots 
        = new List<DepartmentSnapshot>() 
                { new DepartmentSnapshot() { Id = 1, ShortName = "T&I", Name = "Technology and Innvoation" } };

    public Department? GetDepartmentById(int departmentId)
    {
        var snapshot = _snapshots.SingleOrDefault(u => u.Id == departmentId);
        return snapshot == null ? null : Department.Restore(snapshot);
    }

    public List<Department> GetDFDSDepartments()
    {
        var allDepartments = new List<Department>();
        foreach(var dep in _snapshots)
        {
            allDepartments.Add(Department.Restore(dep));
        }
        return allDepartments;
    }
}
