using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstManyToMany.Models
{
  public class Employee
  {
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    [MaxLength(50)]
    public required string LastName { get; set; }
    [Required]
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [NotMapped]
    public string FullName { get { return FirstName + " " + LastName; } }
    public virtual required List<EmployeeProject> EmployeeProject { get; set; } = new();
  }

  public class Project
  {
    [Key]
    public int ProjectId { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    public decimal Budget { get; set; }
    public virtual required List<EmployeeProject> EmployeeProject { get; set; } = new();
  }

  public class EmployeeProject
  {
    public int ProjectId { get; set; }
    public int EmployeeId { get; set; }
    public required Employee Employee { get; set; }
    public required Project Project { get; set; }
  }
}