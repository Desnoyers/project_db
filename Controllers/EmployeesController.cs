using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_bazi.DataAccess;
using project_bazi.Models;
using project_bazi.Services;
using Newtonsoft.Json;

namespace project_bazi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly db_201920z_va_prj_hrmContext _context = new db_201920z_va_prj_hrmContext();

        [HttpGet("GetAll")]
        public async Task<List<EmployeesDto>> GetAll()
        {
            if(AppState.Authenticated == true)
            {
                List<EmployeesDto> list = new List<EmployeesDto>();

                var employees = await _context.Employees.ToListAsync();

                var departments = await _context.Departments.ToListAsync();

                foreach(var emp in employees)
                {
                    EmployeesDto employee = new EmployeesDto();

                    employee.FirstName = emp.FirstName;
                    employee.LastName = emp.LastName;
                    employee.Email = emp.Email;
                    employee.Phone = emp.Phone;
                    employee.City = emp.City;
                    employee.Street = emp.Street;
                    employee.Gender = emp.Gender;
                    employee.BirthDate = emp.BirthDate;
                    employee.Embg = emp.Embg;
                    employee.Salary = emp.Salary;
                    employee.Username = emp.Username;
                    employee.DepNo = emp.DepNo;
                    employee.DepName = emp.DepNoNavigation.DepName;
                    employee.DepManager = emp.DepManager;
                    employee.IsActive = emp.IsActive;
                    employee.IsManaged = emp.IsManagedNavigation.FirstName + " " + emp.IsManagedNavigation.LastName;

                    list.Add(employee);
                }

                return list;
            }
            else
            {
                 return null;
            }
        }
        
        [HttpGet("MyProjects")]
        public async Task<List<WorkOn>> MyProjects()
        {
            if(AppState.Authenticated)
            {
                List<WorkOn> projects = new List<WorkOn>();

                string embg = AppState.UserStateData;

                var all = await _context.WorkOn.Where(x => x.Embg == embg).ToListAsync();

                projects = all; 

                return projects;
            }
            else
            {
                return null;
            }
        }
    }
}
