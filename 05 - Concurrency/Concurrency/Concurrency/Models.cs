using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concurrency
{
  public class Employee
  {
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    [MaxLength(50)]
    [ConcurrencyCheck]
    public string LastName { get; set; }
    [Required]
    [MaxLength(50)]
    [ConcurrencyCheck]
    public string FirstName { get; set; }
    [NotMapped]
    public string FullName { get { return FirstName + " " + LastName; } }
  }
}
