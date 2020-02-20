using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class WorkOn
    {
        public string Embg { get; set; }
        public string ProName { get; set; }

        public virtual Employees EmbgNavigation { get; set; }
        public virtual Projects ProNameNavigation { get; set; }
    }
}
