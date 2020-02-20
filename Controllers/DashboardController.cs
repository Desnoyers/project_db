using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project_bazi.Models;
using project_bazi.Services;

namespace project_bazi.Controllers
{
    public class DashboardController : Controller   // TODO: implement
    {
        [HttpGet]
        public ActionResult Index()
        {

            if (AppState.State == true)
            {
                // return View("../Admin/index");.
                return Ok("Uredu");
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
