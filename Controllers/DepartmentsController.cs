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
    public class DepartmentsController : Controller
    {
        private readonly db_201920z_va_prj_hrmContext _context = new db_201920z_va_prj_hrmContext();

        [HttpGet("GetAll")]
        public async Task<List<Departments>> GetAll()
        {
            if(AppState.Authenticated == true)
            {
                List<Departments> list = new List<Departments>();

                var departments = await _context.Departments.ToListAsync();

                return departments;
            }
            else
            {
                return null;
            }
        }
    }
}
