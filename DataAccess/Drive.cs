using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Drive
    {
        public string RegNo { get; set; }
        public string Embg { get; set; }

        public virtual Employees EmbgNavigation { get; set; }
        public virtual CompanyVehicles RegNoNavigation { get; set; }
    }
}
