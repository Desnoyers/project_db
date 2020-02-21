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


namespace project_bazi.Controllers
{
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
              
                // return Ok(userEmbg);
                return View("../Admin/Index", employee);
            }
            else
            {
                return RedirectToAction("Login","Users");
            }
        }
    }
}
