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
    [Route("[controller]")]
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
            if (AppState.Authenticated == true)
            {
                RedirectToAction("Index", "Dashboard");
            }

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

            AppState.Authenticated = true;

            AppState.UserStateData = user.Embg;

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

            return RedirectToAction("Login");
        }

        [HttpGet("Logout")]
        public ActionResult Logout()
        {
            AppState.Authenticated = false;
            AppState.UserStateData = null;

            return RedirectToAction("Login", "Users");
        }
        private bool existsUsername(string username)
        {
            var user = _context.Employees.Where(x => x.Username == username).FirstOrDefault();

            return user != null ? true : false;
        }
    }
}
