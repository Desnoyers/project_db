using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Payroll
    {
        public int Id { get; set; }
        public decimal Payment { get; set; }
        public DateTime PayDate { get; set; }
        public string EmpEmbg { get; set; }

        public virtual Employees EmpEmbgNavigation { get; set; }
    }
}
