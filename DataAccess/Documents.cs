using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Documents
    {
        public string DocNo { get; set; }
        public string DocType { get; set; }
        public string DocTitle { get; set; }
        public string EmpEmbg { get; set; }

        public virtual Employees EmpEmbgNavigation { get; set; }
    }
}
