using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MigrationWebApp.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Employee> Employee { get; set; }
  }

  public class Employee
  {
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [NotMapped]
    public string FullName { get { return FirstName + " " + LastName; } }

    // Add Years of service
    public int YearsOfServices { get; set; }
    public int Salary { get; set; }
  }
}
