using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Projects
    {
        public Projects()
        {
            WorkOn = new HashSet<WorkOn>();
        }

        public string ProName { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepNo { get; set; }

        public virtual Departments DepNoNavigation { get; set; }
        public virtual ICollection<WorkOn> WorkOn { get; set; }
    }
}
