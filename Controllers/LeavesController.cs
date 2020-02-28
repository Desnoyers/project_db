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
using project_bazi.Services;
using project_bazi.Models;

namespace project_bazi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : Controller
    {
        private readonly db_201920z_va_prj_hrmContext _context = new db_201920z_va_prj_hrmContext();

        [HttpGet("GetAll")]
        public async Task<List<LeavesModel>> GetAll()
        {
            if (AppState.Authenticated == true)
            {
                List<LeavesModel> list = new List<LeavesModel>();

                var leaves = await _context.Leaves.ToListAsync();

                var employees = await _context.Employees.ToListAsync();

                foreach(var item in leaves)
                {
                    LeavesModel leave = new LeavesModel();

                    leave.LeaveId = item.LeaveId;
                    leave.Description = item.Description;
                    leave.EmpEmbg = item.EmpEmbg;
                    leave.EmpName = item.EmpEmbgNavigation.FirstName + " " + item.EmpEmbgNavigation.LastName;
                    leave.FromDate = item.Fromdate.Date;
                    leave.ToDate = item.Todate;
                    leave.LeaveStatus = item.LeaveStatus;

                    list.Add(leave);
                }

                return list;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("MyLeaves")]
        public async Task<List<Leaves>> MyLeaves()
        {
            if (AppState.Authenticated == true)
            {
                string embg = AppState.UserStateData;

                List<Leaves> list = new List<Leaves>();

                list = await _context.Leaves.Where(x => x.EmpEmbg == embg).ToListAsync();

                return list;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("Approve/{id}")]
        public async Task<ActionResult> Approve(int id)
        {
            var leave = _context.Leaves.Find(id);

            leave.LeaveStatus = "Approved";

            _context.Entry(leave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                ex.GetBaseException();
            }

            return Ok(leave);
        }

        [HttpGet("Decline/{id}")]
        public async Task<ActionResult> Decline(int id)
        {
            var leave = _context.Leaves.Find(id);

            leave.LeaveStatus = "denied";

            _context.Entry(leave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                ex.GetBaseException();
            }

            return Ok(leave);
        }

    }
}
