using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
   public class Employee : IBaseEntity
   {
      [Key]
      public int Id { get; set; }

      [Required]
      public string Name { get; set; } = string.Empty;
      
      [Required]
      public string Gender { get; set; } = string.Empty;
      
      public int? Salary { get; set; }
      public int? DepartmentId { get; set; }

      //public Department Department { get; set; }
   }
}