using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class CompanyVehicles
    {
        public CompanyVehicles()
        {
            Drive = new HashSet<Drive>();
        }

        public string RegNo { get; set; }
        public string Model { get; set; }
        public string VeType { get; set; }
        public DateTime? Year { get; set; }

        public virtual ICollection<Drive> Drive { get; set; }
    }
}
