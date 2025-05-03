using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6xCodeFirst.Models
{
  public class Employee
  {
    [Key]
    public int EmployeeId { get; set; }
    // [ForeignKey("DepartmentId")]
    // public int DepartmentId { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [NotMapped]
    public string FullName { get { return FirstName + " " + LastName; } }
  }

  public class Department
  {
    [Key]
    public int DepartmentId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
  }
}
