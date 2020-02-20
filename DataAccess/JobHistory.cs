using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class JobHistory
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EmpEmbg { get; set; }

        public virtual Employees EmpEmbgNavigation { get; set; }
    }
}
