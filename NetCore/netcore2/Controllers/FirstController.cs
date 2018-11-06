using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using netcore2.Models;

namespace netcore2.Controllers     
{
    public class FirstController : Controller  
    {
        [HttpGet]       
        [Route("")]     
        public IActionResult firstpage()
        {
           Message amessage = new Message(){
               contents = "Hi, This is message page. I am using C# and asp.net. Now listening on: http://localhost:5000"
           };

           return View("firstpage",amessage);
        }

        [HttpGet]       
        [Route("numbers")]     
        public IActionResult secondpage()
        {
            Number allNumbers = new Number(){
                numbers = new int[]{1,2,3,4,5,6,7,8,9,10}
            };
            return View("secondpage", allNumbers);
        }
        [HttpGet]       
        [Route("users")]     
        public IActionResult thirdpage()
        {
            List<string> temp = new List<string>();
            temp.Add("Shawn");
            temp.Add("John");
            temp.Add("Dexter");
            temp.Add("Roco");
            temp.Add("Rico");
            temp.Add("Letitgo");
            temp.Add("Whatisgoingon");
            Users allUsers = new Users(){
                people = temp
            };
            return View("thirdpage",allUsers);
        }

        [HttpGet]       
        [Route("user")]     
        public IActionResult fourthpage()
        {
            return View("fourthpage");
        }

        [HttpPost]       
        [Route("user")]     
        public IActionResult userpost(User submitted)
        {
            return View("fourthpage");
        }
    }
}