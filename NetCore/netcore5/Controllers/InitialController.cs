using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;  // to use controller
using netcore5.Models; // to use Models 
using Microsoft.AspNetCore.Http; // to use session
using netcore5.Factory;

namespace netcore5.Controllers   
{
    public class InitialController : Controller 
    {
        private readonly UserFactory userFactory;
        public InitialController(){
            userFactory = new UserFactory();
        }
        [HttpGet]   
        [Route("")]    
        public IActionResult Main()
        {
            return View("Initial");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Posting(User user){
            userFactory.Add(user);
            return RedirectToAction("showing");
        }

        [HttpGet]   
        [Route("quotes")]    
        public IActionResult showing()
        {
            ViewBag.allusers = userFactory.FindAll();
            return View("show");
        }
    }
}