using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project_bazi.Models;
using project_bazi.Services;
using project_bazi.DataAccess;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace project_bazi.Controllers
{
    [Route("[Controller]")]
    [Controller]
    public class DashboardController : Controller   // TODO: implement
    {
        private readonly db_201920z_va_prj_hrmContext _context = new db_201920z_va_prj_hrmContext();

        [HttpGet]
        public ActionResult Index()
        {

            if (AppState.Authenticated == true)
            {
                string userEmbg = AppState.UserStateData;

                var user = _context.Employees.Find(userEmbg);

                EmployeesDto employee = new EmployeesDto();

                #region Emp initialization

                employee.Embg = user.Embg;
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.IsActive = user.IsActive;
                employee.IsManaged = user.IsManaged;
                employee.Phone = user.Phone;
                employee.Email = user.Email;
                employee.Gender = user.Gender;
                employee.Salary = user.Salary;
                employee.Street = user.Street;
                employee.StreetNo = user.StreetNo;
                employee.Username = user.Username;
                employee.Password = user.Password;
                employee.City = user.City;
                employee.BirthDate = user.BirthDate;
                employee.DepManager = user.DepManager;
                employee.DepNo = user.DepNo;

                #endregion

                if (employee.DepManager != null)
                {
                    return View("../Admin/Index", employee);
                }
                else
                {
                    return View("../Regular/Index", employee);
                }
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // GET: Dashboard/Employees
        [HttpGet("Employees")]
        public ActionResult Employees()
        {
            if (AppState.Authenticated == true)
            {
                string userEmbg = AppState.UserStateData;

                var user = _context.Employees.Find(userEmbg);

                EmployeesDto employee = new EmployeesDto();

                #region Emp initialization

                employee.Embg = user.Embg;
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.IsActive = user.IsActive;
                employee.IsManaged = user.IsManaged;
                employee.Phone = user.Phone;
                employee.Email = user.Email;
                employee.Gender = user.Gender;
                employee.Salary = user.Salary;
                employee.Street = user.Street;
                employee.StreetNo = user.StreetNo;
                employee.Username = user.Username;
                employee.Password = user.Password;
                employee.City = user.City;
                employee.BirthDate = user.BirthDate;
                employee.DepManager = user.DepManager;
                employee.DepNo = user.DepNo;
                // employee.DepName = user.DepNoNavigation.DepName;

                #endregion

                return View("../Admin/Employees", employee);
            }
            else
            {
                return View("../Users/Login");
            }
        }

        [HttpPost("Employees/Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([FromForm] EmployeesDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employees newEmp = new Employees();

            newEmp.Embg = employee.Embg;
            newEmp.FirstName = employee.FirstName;
            newEmp.LastName = employee.LastName;
            newEmp.Gender = employee.Gender;
            newEmp.Email = employee.Email;
            newEmp.BirthDate = employee.BirthDate;
            newEmp.City = employee.City;
            newEmp.DepManager = null;

            var department = _context.Departments.Where(x => x.DepName == employee.DepName).FirstOrDefault();

            newEmp.DepNo = department.DepNo;

            newEmp.IsActive = 1;
            newEmp.Street = employee.Street;
            newEmp.StreetNo = employee.StreetNo;
            newEmp.Salary = employee.Salary;
            newEmp.Phone = employee.Phone;

            newEmp.Username = null;
            newEmp.Password = null;

            // var manager = _context.Employees.Where(x => x.DepNo == department.DepNo)

            newEmp.IsManaged = "08121997450264";

            var user = _context.Employees.Find(newEmp.Embg);

            if (user != null)
            {
                return BadRequest("Employee exists");
            }
            else
            {
                _context.Employees.Add(newEmp);

            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ex.GetBaseException();
            }

            return RedirectToAction("Employees", "Dashboard");
        }

        [HttpGet("Employees/Add")]
        public ActionResult Add()
        {
            if (AppState.Authenticated == true)
            {
                string userEmbg = AppState.UserStateData;

                var user = _context.Employees.Find(userEmbg);

                EmployeesDto employee = new EmployeesDto();

                #region Emp initialization

                employee.Embg = user.Embg;
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.IsActive = user.IsActive;
                employee.IsManaged = user.IsManaged;
                employee.Phone = user.Phone;
                employee.Email = user.Email;
                employee.Gender = user.Gender;
                employee.Salary = user.Salary;
                employee.Street = user.Street;
                employee.StreetNo = user.StreetNo;
                employee.Username = user.Username;
                employee.Password = user.Password;
                employee.City = user.City;
                employee.BirthDate = user.BirthDate;
                employee.DepManager = user.DepManager;
                employee.DepNo = user.DepNo;

                #endregion

                if (employee.DepManager != null)
                {
                    return View("../Admin/AddEmployee", employee);
                }
                else
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpGet("Departments")]
        public ActionResult Departments()
        {
            if (AppState.Authenticated == true)
            {
                string userEmbg = AppState.UserStateData;

                var user = _context.Employees.Find(userEmbg);

                EmployeesDto employee = new EmployeesDto();

                #region Emp initialization

                employee.Embg = user.Embg;
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.IsActive = user.IsActive;
                employee.IsManaged = user.IsManaged;
                employee.Phone = user.Phone;
                employee.Email = user.Email;
                employee.Gender = user.Gender;
                employee.Salary = user.Salary;
                employee.Street = user.Street;
                employee.StreetNo = user.StreetNo;
                employee.Username = user.Username;
                employee.Password = user.Password;
                employee.City = user.City;
                employee.BirthDate = user.BirthDate;
                employee.DepManager = user.DepManager;
                employee.DepNo = user.DepNo;

                #endregion

                return View("../Admin/Departments", employee);

            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpGet("Departments/AddDep")]
        public ActionResult AddDep()
        {
            if (AppState.Authenticated == true)
            {
                string userEmbg = AppState.UserStateData;

                var user = _context.Employees.Find(userEmbg);

                EmployeesDto employee = new EmployeesDto();

                #region Emp initialization

                employee.Embg = user.Embg;
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.IsActive = user.IsActive;
                employee.IsManaged = user.IsManaged;
                employee.Phone = user.Phone;
                employee.Email = user.Email;
                employee.Gender = user.Gender;
                employee.Salary = user.Salary;
                employee.Street = user.Street;
                employee.StreetNo = user.StreetNo;
                employee.Username = user.Username;
                employee.Password = user.Password;
                employee.City = user.City;
                employee.BirthDate = user.BirthDate;
                employee.DepManager = user.DepManager;
                employee.DepNo = user.DepNo;

                #endregion

                if (employee.DepManager != null)
                {
                    return View("../Admin/AddDepartment", employee);
                }
                else
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpPost("Departments/AddDep")]
        [ValidateAntiForgeryToken]
        public ActionResult AddDep([FromForm] Departments department)
        {
            if (AppState.Authenticated != true)
            {
                return RedirectToAction("Login", "Users");
            }

            var exist = _context.Departments.Find(department.DepNo);

            if (exist != null)
            {
                return BadRequest("Department number exist");
            }

            _context.Departments.Add(department);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ex.GetBaseException();
            }

            return RedirectToAction("Departments", "Dashboard");
        }

        [HttpGet("Leaves")]
        public ActionResult Leaves()
        {
            if (AppState.Authenticated == true)
            {
                string userEmbg = AppState.UserStateData;

                var user = _context.Employees.Find(userEmbg);

                EmployeesDto employee = new EmployeesDto();

                #region Emp initialization

                employee.Embg = user.Embg;
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.IsActive = user.IsActive;
                employee.IsManaged = user.IsManaged;
                employee.Phone = user.Phone;
                employee.Email = user.Email;
                employee.Gender = user.Gender;
                employee.Salary = user.Salary;
                employee.Street = user.Street;
                employee.StreetNo = user.StreetNo;
                employee.Username = user.Username;
                employee.Password = user.Password;
                employee.City = user.City;
                employee.BirthDate = user.BirthDate;
                employee.DepManager = user.DepManager;
                employee.DepNo = user.DepNo;

                #endregion

                return View("../Admin/Leaves", employee);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpGet("MyLeaves")]
        public ActionResult MyLeaves()
        {
            if (AppState.Authenticated == true)
            {
                string userEmbg = AppState.UserStateData;

                var user = _context.Employees.Find(userEmbg);

                EmployeesDto employee = new EmployeesDto();

                #region Emp initialization

                employee.Embg = user.Embg;
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.IsActive = user.IsActive;
                employee.IsManaged = user.IsManaged;
                employee.Phone = user.Phone;
                employee.Email = user.Email;
                employee.Gender = user.Gender;
                employee.Salary = user.Salary;
                employee.Street = user.Street;
                employee.StreetNo = user.StreetNo;
                employee.Username = user.Username;
                employee.Password = user.Password;
                employee.City = user.City;
                employee.BirthDate = user.BirthDate;
                employee.DepManager = user.DepManager;
                employee.DepNo = user.DepNo;

                #endregion

                return View("../Regular/Leaves", employee);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpPost("Leaves/RequestLeave")]
        public ActionResult RequestLeave([FromForm] LeavesModel leave)
        {
            if (AppState.Authenticated == true)
            {
                Leaves le = new Leaves();

                le.LeaveId = leave.LeaveId;
                le.Description = leave.Description;
                le.EmpEmbg = AppState.UserStateData;
                le.LeaveStatus = "Pending";
                le.Fromdate = leave.FromDate;
                le.Todate = leave.ToDate;

                _context.Leaves.Add(le);

                try
                {
                    _context.SaveChanges();
                }
                catch(DbUpdateException ex)
                {
                    ex.GetBaseException();
                }

                return RedirectToAction("MyLeaves", "Dashboard");
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }
    }
}
