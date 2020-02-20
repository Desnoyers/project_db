using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Has
    {
        public string Embg { get; set; }
        public int SkillId { get; set; }

        public virtual Employees EmbgNavigation { get; set; }
        public virtual Skills Skill { get; set; }
    }
}
