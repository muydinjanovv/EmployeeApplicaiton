using Task.Entities;

namespace Task.Models;

public class EmployeeViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime StartDate { get; set; }
    public EPositions Position { get; set; }
    public int CompanyId { get; set; }
}