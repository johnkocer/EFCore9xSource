using System;
using System.Collections.Generic;

namespace DatabaseFirstMany2Many.EfDbFirstMany2ManyModels
{
    public partial class EmployeeProject
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
