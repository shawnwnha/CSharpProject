using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore3.Models;

namespace netcore3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]       
        [Route("")]  
        public IActionResult Index()
        {
            return View();
        }
    }
}
