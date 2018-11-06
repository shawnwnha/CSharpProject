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
    public class HomeController : Controller
    {
        private Temp thisuser;  
        private HomeContext _context;

        [HttpGet]
        [Route("main")]
        public IActionResult Main()
        {
            int? x = HttpContext.Session.GetInt32("ID");
            if(x == null) {
                return RedirectToAction("Login","Account");
            }
            // if(uID != x){
            //     return RedirectToAction("Main", new{uID = x});
            // }
            else{
                List<Message> allMessages = _context.messages.Include(data => data.User).Include(data => data.Comments).OrderByDescending(data => data.created_at).ToList();
                ViewBag.allmessages = allMessages;
                return View();
            }
        }
        [HttpPost]
        [Route("main")]
        public IActionResult Main(Message msg){
            int? x = HttpContext.Session.GetInt32("ID");
            if(ModelState.IsValid){
                msg.created_at = DateTime.Now;
                msg.updated_at = DateTime.Now;
                msg.UserId = (int)x;

                _context.messages.Add(msg);
                _context.SaveChanges();
            }
            List<Message> allMessages = _context.messages.Include(data => data.User).Include(data => data.Comments).OrderByDescending(data => data.created_at).ToList();
            ViewBag.allmessages = allMessages;
            return View("Main");    
        }
        [HttpPost]
        [Route("postmessage/{x}")]
        public IActionResult Postmessage(int x, string cmt){
            int? I = HttpContext.Session.GetInt32("ID");
            Console.WriteLine(cmt);
            Console.WriteLine(x);
            Comment newCmt = new Comment{
                Content = cmt,
                created_at =DateTime.Now,
                updated_at = DateTime.Now,
                UserId = (int)I,
                MessageId = x 
            };
            _context.comments.Add(newCmt);
            _context.SaveChanges();
            List<Message> allMessages = _context.messages.Include(data => data.User).Include(data => data.Comments).OrderByDescending(data => data.created_at).ToList();
            ViewBag.allmessages = allMessages;
            return View("Main");
        } 
    }
}
