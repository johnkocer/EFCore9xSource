using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartItCodecamp.Models
{
   public class Course
   {
      [DatabaseGenerated(DatabaseGeneratedOption.None)]
      [Display(Name = "Number")]
      public int Id { get; set; }

      [StringLength(50, MinimumLength = 3)]
      public string Title { get; set; } = string.Empty;

      [Range(0, 3)]
      public int Grade { get; set; }
      public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
   }
}