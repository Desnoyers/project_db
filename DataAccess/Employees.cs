using System;
using System.Collections.Generic;

namespace project_bazi.DataAccess
{
    public partial class Employees
    {
        public Employees()
        {
            Attendance = new HashSet<Attendance>();
            Documents = new HashSet<Documents>();
            Drive = new HashSet<Drive>();
            Has = new HashSet<Has>();
            InverseIsManagedNavigation = new HashSet<Employees>();
            JobHistory = new HashSet<JobHistory>();
            Leaves = new HashSet<Leaves>();
            Payroll = new HashSet<Payroll>();
            TakePart = new HashSet<TakePart>();
            WorkOn = new HashSet<WorkOn>();
        }

        public string Embg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public int DepNo { get; set; }
        public string IsManaged { get; set; }
        public int? DepManager { get; set; }
        public int IsActive { get; set; }

        public virtual Departments DepManagerNavigation { get; set; }
        public virtual Departments DepNoNavigation { get; set; }
        public virtual Employees IsManagedNavigation { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<Drive> Drive { get; set; }
        public virtual ICollection<Has> Has { get; set; }
        public virtual ICollection<Employees> InverseIsManagedNavigation { get; set; }
        public virtual ICollection<JobHistory> JobHistory { get; set; }
        public virtual ICollection<Leaves> Leaves { get; set; }
        public virtual ICollection<Payroll> Payroll { get; set; }
        public virtual ICollection<TakePart> TakePart { get; set; }
        public virtual ICollection<WorkOn> WorkOn { get; set; }
    }
}
