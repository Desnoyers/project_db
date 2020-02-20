using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class TakePart
    {
        public string Embg { get; set; }
        public int TrId { get; set; }

        public virtual Employees EmbgNavigation { get; set; }
        public virtual Trainings Tr { get; set; }
    }
}
