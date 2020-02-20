using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Leaves
    {
        public int LeaveId { get; set; }
        public string Description { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public string LeaveStatus { get; set; }
        public string EmpEmbg { get; set; }

        public virtual Employees EmpEmbgNavigation { get; set; }
    }
}
