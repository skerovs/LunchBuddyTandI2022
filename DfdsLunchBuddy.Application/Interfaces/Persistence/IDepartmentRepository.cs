using DfdsLunchBuddy.Domain.DomainObjects;

namespace DfdsLunchBuddy.Application.Common.Interfaces.Persistence;

public interface IDepartmentRepository
{
    Department? GetDepartmentById(int id);
    List<Department> GetDFDSDepartments();
}