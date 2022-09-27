using Task.Entities;
using Task.Models;

namespace Task.Mappers;

public static class EmployeeMappers
{
    public static Employee ToEntity(this EmployeeViewModel model)
        => new Employee()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            MiddleName = model.MiddleName,
            StartDate = model.StartDate,
            Position = model.Position,
            CompanyId = model.CompanyId
        };

    public static EmployeeViewModel ToModel(this Employee employee)
        => new EmployeeViewModel()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            MiddleName = employee.MiddleName,
            StartDate = employee.StartDate,
            Position = employee.Position
        };
}