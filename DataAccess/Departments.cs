using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Departments
    {
        public Departments()
        {
            EmployeesDepManagerNavigation = new HashSet<Employees>();
            EmployeesDepNoNavigation = new HashSet<Employees>();
            Projects = new HashSet<Projects>();
            Trainings = new HashSet<Trainings>();
        }

        public int DepNo { get; set; }
        public string DepName { get; set; }

        public virtual ICollection<Employees> EmployeesDepManagerNavigation { get; set; }
        public virtual ICollection<Employees> EmployeesDepNoNavigation { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<Trainings> Trainings { get; set; }
    }
}
