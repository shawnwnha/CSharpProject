using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Http; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RReviews.Models; 

namespace RReviews.Controllers{
    public class MainController : Controller
    {
        private MainContext _context;
    
        public MainController(MainContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Post> AllPosts = _context.posts.ToList();
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult PostReview(Post data)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine(data);
                _context.posts.Add(data);
                _context.SaveChanges();
                return RedirectToAction("AllReviews");
            }
            else
            {
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult AllReviews()
        {
            List<Post> allPosts = _context.posts.OrderByDescending(data =>data.Datevisit).ToList();
            ViewBag.alls = allPosts;
            return View();
        }

        // [HttpGet]
        // [Route("one")]
        // public IActionResult One()
        // {
        //     List<Person> AllUsers = _context.Users.Where(data =>data.Age == 26).ToList();
        //     return View();
        // }

        // [HttpGet]
        // [Route("one/{Age}")]
        // public IActionResult One(int Age)
        // {
        //     Person OneUser = _context.Users.SingleOrDefault(data => data.Age == Age);
        //     return View();
        // }

        // [HttpGet]
        // [Route("create")]
        // public IActionResult Create(){
        //     Person newPerson = new Person(){
        //         Name = "Michael",
        //         Email = "Michael@Jackson.com",
        //         Password = "123123123", 
        //         Age = 45
        //     };
        //     _context.Users.Add(newPerson);
        //     _context.SaveChanges();
        //     return View();
        // }

        // [HttpGet]
        // [Route("update")]
        // public IActionResult Update(){
        //     Person OneUser = _context.Users.SingleOrDefault(data =>data.Age ==26);
        //     OneUser.Name = "SHAWNKING";
        //     _context.SaveChanges();
        //     return View();
        // }

        // [HttpGet]
        // [Route("remove")]
        // public IActionResult Remove(){
        //     Person OneUser = _context.Users.SingleOrDefault(data =>data.Age ==45);
        //     _context.Users.Remove(OneUser);
        //     _context.SaveChanges();
        //     return View();
        // }
    }
}
