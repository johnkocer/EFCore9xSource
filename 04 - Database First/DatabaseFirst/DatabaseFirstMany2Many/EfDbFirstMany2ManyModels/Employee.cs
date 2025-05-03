using System;
using System.Collections.Generic;

namespace DatabaseFirstMany2Many.EfDbFirstMany2ManyModels
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeProject = new HashSet<EmployeeProject>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProject { get; set; }
    }
}
