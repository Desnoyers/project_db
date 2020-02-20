using System;

namespace project_bazi.Models
{
    public class EmployeesDto
    {
        public EmployeesDto()
        {
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
    }
}