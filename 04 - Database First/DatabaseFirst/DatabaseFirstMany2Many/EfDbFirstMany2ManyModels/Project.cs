using System;
using System.Collections.Generic;

namespace DatabaseFirstMany2Many.EfDbFirstMany2ManyModels
{
    public partial class Project
    {
        public Project()
        {
            EmployeeProject = new HashSet<EmployeeProject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProject { get; set; }
    }
}
