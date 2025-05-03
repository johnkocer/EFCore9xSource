using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstOne2One.Models
{
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
    public virtual Address Address { get; set; }
  }

  public class Address
  {
    [Key]
    public int AddressId { get; set; }
    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
    [MaxLength(100)]
    public string HomeAddress { get; set; }
    [MaxLength(100)]
    public string City { get; set; }
    [MaxLength(2)]
    public string Sate { get; set; }
    [MaxLength(5)]
    public string Zip { get; set; }
    public virtual Employee Employee { get; set; }

  }
}


