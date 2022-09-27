using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }    
    public string LastName { get; set; }    
    public string MiddleName { get; set; }
    public DateTime StartDate { get; set; }   
    public EPositions Position { get; set; } 
    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }
    public int CompanyId { get; set; }
}