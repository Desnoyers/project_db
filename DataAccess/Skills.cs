using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Skills
    {
        public Skills()
        {
            Has = new HashSet<Has>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Details { get; set; }

        public virtual ICollection<Has> Has { get; set; }
    }
}
