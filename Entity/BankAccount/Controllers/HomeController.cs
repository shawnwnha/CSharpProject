using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankAccount.Models;

namespace BankAccount.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext _context;
        public HomeController(HomeContext context){
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Register(User aUser)
        {
            if(ModelState.IsValid){
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                string x = Hasher.HashPassword(aUser,aUser.Password);
                aUser.Password = x;
                aUser.Confirm = x;
                _context.users.Add(aUser);
                _context.SaveChanges();
                return RedirectToAction("Main");
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
                        HttpContext.Session.SetInt32("ID",thisUser.UserId);
                        return RedirectToAction("Main");
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
        [HttpGet]
        [Route("main")]
        public IActionResult Main()
        {
            if(HttpContext.Session.GetInt32("ID") == null) {
                return RedirectToAction("Login");
            }
            else{
                int? x = HttpContext.Session.GetInt32("ID");
                List<Book> allBooks = _context.books.Include(data => data.User).Where(data => data.UserId == (int)x).OrderByDescending(data => data.DateT).ToList();
                double currentBalance;
                if(allBooks.Count == 0){
                    currentBalance = 0;
                }
                else{
                    currentBalance = allBooks[0].Balance;
                }
                User thisUser = _context.users.FirstOrDefault(data => data.UserId == (int)x);
                ViewBag.allbooks = allBooks;
                ViewBag.thisuser = thisUser;
                ViewBag.currentbalance = currentBalance;
                ViewBag.Error = TempData["Error"];
                return View();
            }
        }
        [HttpPost]
        [Route("main")]
        public IActionResult PostTransaction(double AmountT){
            int? x = HttpContext.Session.GetInt32("ID");
            List<Book> allBooks = _context.books.Include(data => data.User).Where(data => data.UserId == (int)x).OrderByDescending(data => data.DateT).ToList();
            double currentBalance;
            if(allBooks.Count == 0){
                currentBalance = 0;
            }
            else{
                currentBalance = allBooks[0].Balance;
            }
            if(currentBalance + AmountT <0){
                TempData["Error"] = "Insufficient fund to withdraw";
            }
            else{
                double bal = currentBalance +AmountT;
                Book temp = new Book{
                    Balance = bal,
                    AmountT = AmountT,
                    DateT = DateTime.Now,
                    UserId = (int)x
                };
                _context.books.Add(temp);
                _context.SaveChanges();
            }
            return RedirectToAction("Main");
        }

    }
}
