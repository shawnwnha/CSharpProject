using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wall.Models;

namespace Wall.Controllers
{
    public class AccountController : Controller
    {
        private HomeContext _context;
        public AccountController(HomeContext context){
            _context = context;
        }
        private bool UserExists(string email)
        {
            if(_context.users.Where(data => data.Email == email).Count() > 0){
                return true;
            } 
            else{
                return false;
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index() //registration 
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        public IActionResult SubmitUser(User aUser){
            if(UserExists(aUser.Email)){
                ModelState.AddModelError("Email", "Email is in use");
            }
            if(ModelState.IsValid){
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                string x = Hasher.HashPassword(aUser,aUser.Password);
                User NewUser = new User {
                    Firstname = aUser.Firstname,
                    Lastname = aUser.Lastname,
                    Email = aUser.Email,
                    Password = x,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                _context.users.Add(NewUser); // please check with briahnna about confirmation password
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            else{
                return View("Index");
            }
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
                        int? uID = thisUser.UserId; 
                        HttpContext.Session.SetInt32("ID",(int)uID);
                        return RedirectToAction("Main","Home");
                        // return RedirectToAction("Main","Home", new {uID=uID});
                    }
                    else{
                        ViewBag.Error = "Matching Password Failed.";
                        return View("Login");
                    }
                }
                else{
                    ViewBag.Error = "No User Record Found.";
                    return View("Login");
                }
            }
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
