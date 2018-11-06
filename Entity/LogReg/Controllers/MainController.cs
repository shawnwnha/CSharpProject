using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LogReg.Models;

namespace LogReg.Controllers{
    public class MainController: Controller{
        private MainContext _context;
        public MainController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           List<User> allUsers = _context.users.ToList();
           return View();
        }
        [HttpPost]
        [Route("")]
        public IActionResult register(User aUser)
        {
            if(ModelState.IsValid){
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                string x = Hasher.HashPassword(aUser,aUser.Password);
                aUser.Password = x;
                aUser.Confirm = x;
                _context.users.Add(aUser);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            else{
                return View("Index");
            }
        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
           List<User> allUsers = _context.users.ToList();
           int? x = HttpContext.Session.GetInt32("ID");
           User thisUser = _context.users.SingleOrDefault(data => data.Id == (int)x);
           ViewBag.allusers = allUsers;
           ViewBag.thisuser = thisUser;
           return View();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
           return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult PostLogin(string ID, string PW)
        {
            if(ID==null || PW==null){
                ViewBag.Error = "ALL INPUTS MUST BE FILLED";
                return View("Login");
            }
            else{
                User thisUser = _context.users.SingleOrDefault(data => data.Email == ID);
                if(thisUser != null){
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(thisUser, thisUser.Password, PW)){
                        HttpContext.Session.SetInt32("ID",thisUser.Id);
                        return RedirectToAction("Success");
                    }
                    else{
                        ViewBag.Error = "Matching Password Failed. ";
                        return View("Login");
                    }
                }
                else{
                    ViewBag.Error = "No User Record Found.";
                    return View("Login");
                }
            }
        }
    }
}