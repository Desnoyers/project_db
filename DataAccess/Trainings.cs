using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Trainings
    {
        public Trainings()
        {
            TakePart = new HashSet<TakePart>();
        }

        public int TrId { get; set; }
        public string TrName { get; set; }
        public string Description { get; set; }
        public int DepNo { get; set; }

        public virtual Departments DepNoNavigation { get; set; }
        public virtual ICollection<TakePart> TakePart { get; set; }
    }
}
