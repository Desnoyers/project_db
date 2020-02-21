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
    [EnableCors("EnableCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {        
        private readonly db_201920z_va_prj_hrmContext _context = new db_201920z_va_prj_hrmContext();

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet("login")]
        public ActionResult Login()
        {
            return View("../Users/Login");
        }

        [HttpGet("register")]
        public ActionResult Register()
        {
            return View("../Users/Register");
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult<string> Login([FromForm] LoginModel emp)
        {
            var user = _context.Employees.Where(x => x.Username == emp.Username).FirstOrDefault();

            if (user == null)
            {
                return NotFound("No such user");
            }

            var pw = Crypto.VerifyHashedPassword(user.Password, emp.Password);

            if (pw == false)
            {
                return BadRequest("incorrect password");
            }
            
            // EmployeesDto employee = new EmployeesDto();

            // #region Emp initialization
            // employee.Embg = user.Embg;
            // employee.FirstName = user.FirstName;
            // employee.LastName = user.LastName;
            // employee.IsActive = user.IsActive;
            // employee.IsManaged = user.IsManaged;
            // employee.Phone = user.Phone;
            // employee.Email = user.Email;
            // employee.Gender = user.Gender;
            // employee.Salary = user.Salary;
            // employee.Street = user.Street;
            // employee.StreetNo = user.StreetNo;
            // employee.Username = user.Username;
            // employee.Password = user.Password;
            // employee.City = user.City;
            // employee.BirthDate = user.BirthDate;
            // employee.DepManager = user.DepManager;
            // employee.DepNo = user.DepNo;
            // #endregion

            AppState.Authenticated = true;
            
            // TempData["object"] = JsonConvert.SerializeObject(user.Embg);
            TempData["object"] = user.Embg;

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register([FromForm] RegisterModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emp = _context.Employees.Find(data.Embg);

            if (emp == null)
            {
                return NotFound("User does not exist");
            }

            if (emp.Username != null || emp.Password != null)
            {
                return BadRequest("Already registered");
            }

            if (data.Password != data.ConfirmPassword)
            {
                return BadRequest("Passwords do not match");
            }

            emp.Username = data.Username;
            emp.Password = Crypto.HashPassword(data.Password);

            _context.Entry(emp).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.GetBaseException();
            }

            return Ok("Registered");
        }

        [HttpPost("Logout")]
        public ActionResult Logout()
        {
            AppState.Authenticated = false;

            return RedirectToAction("Login", "Users");
        }
        private bool existsUsername(string username)
        {
            var user = _context.Employees.Where(x => x.Username == username).FirstOrDefault();

            return user != null ? true : false;
        }
    }
}
