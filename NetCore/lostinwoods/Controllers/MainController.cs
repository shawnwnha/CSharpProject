using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;  // to use controller
using lostinwoods.Models; // to use Models 
using Microsoft.AspNetCore.Http; // to use session
using lostinwoods.Factory; // to use Dapper Factory 

namespace lostinwoods.Controllers   
{
    public class MainController : Controller 
    {
        private readonly MainFactory _mainfactory;
        public MainController(MainFactory mFactory){
            _mainfactory = mFactory;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var x = _mainfactory.FindAll();
            ViewBag.trails = _mainfactory.FindAll();
            return View("Index");
        }

        [HttpGet]
        [Route("NewTrail")]
        public IActionResult New()
        {
            return View("New");
        }
        [HttpPost]
        [Route("NewTrail")]
        public IActionResult Add(Trail trail)
        {
            if(ModelState.IsValid)
            {
                _mainfactory.Add(trail);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }
        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult showOne(int id){
            var x = _mainfactory.FindByID(id);
            ViewBag.trail = _mainfactory.FindByID(id);
            return View("One");
        }
    }
}