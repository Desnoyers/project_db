using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Attendance
    {
        public int AttId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string EmpEmbg { get; set; }

        public virtual Employees EmpEmbgNavigation { get; set; }
    }
}
