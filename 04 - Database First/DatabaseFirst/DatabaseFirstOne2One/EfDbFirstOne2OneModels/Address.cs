using System;
using System.Collections.Generic;

namespace DatabaseFirstOne2One.EfDbFirstOne2OneModels
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int EmployeeId { get; set; }
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string Sate { get; set; }
        public string Zip { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
