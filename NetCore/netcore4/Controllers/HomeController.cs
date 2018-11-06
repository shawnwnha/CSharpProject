using System;
using Microsoft.AspNetCore.Mvc;  // to use controller
using netcore4.Models; // to use Models 
using Microsoft.AspNetCore.Http; // to user session
namespace netcore4.Controllers   
{
    public class HomeController : Controller 
    {
        private string GetRandom(){
            string allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            string newchars = "";
            for(var i = 0; i < 14;i++){
                newchars += allChars[rand.Next(0,36)];
            }
            return newchars;
        }

        [HttpGet]   
        [Route("")]    
        public IActionResult Index()
        {
            return View("Home");
        }

        [HttpGet]   
        [Route("random")]    
        public IActionResult RandomGen()
        {
            if(HttpContext.Session.GetInt32("trial")==null){
                HttpContext.Session.SetInt32("trial",0);
                ViewBag.Trial = HttpContext.Session.GetInt32("trial");
                ViewBag.RandNums = GetRandom();
                HttpContext.Session.();
            }
            else{
                int temp = (int) HttpContext.Session.GetInt32("trial");
                temp ++;
                HttpContext.Session.SetInt32("trial",temp);
                ViewBag.Trial = HttpContext.Session.GetInt32("trial");
                ViewBag.RandNums = GetRandom();
            }
            return View("Random");
        }

        [HttpPost]   
        [Route("newuser")]
        public IActionResult Create(User submittedUser){
            if(ModelState.IsValid){
                HttpContext.Session.SetString("UserName", submittedUser.FirstName);
                return RedirectToAction("Done", submittedUser);
            }
            else{
                return View("Home");
            }
        }
        [HttpGet]   
        [Route("result")]
        public IActionResult Done(User passedUser){
            string testUserName = HttpContext.Session.GetString("UserName");
            return View("NewUser",passedUser);
        }
// --------------------------------------------------DOJODACHI-----------------------------------
        [HttpGet]
        [Route("dojodachi")]
        public IActionResult dojodachi(){
            if(HttpContext.Session.GetInt32("fullness")==null){
                Dojo temp = new Dojo();
                HttpContext.Session.SetInt32("fullness", temp.fullness);
                HttpContext.Session.SetInt32("happiness", temp.happiness);
                HttpContext.Session.SetInt32("energy", temp.energy);
                HttpContext.Session.SetInt32("meals", temp.meals);
                HttpContext.Session.SetString("message", temp.message);
                ViewBag.fullness = temp.fullness;
                ViewBag.happiness = temp.happiness;
                ViewBag.energy = temp.energy;
                ViewBag.meals = temp.meals;
                ViewBag.message = temp.message;
            }
            else{
                int? full = HttpContext.Session.GetInt32("fullness");
                int? happ = HttpContext.Session.GetInt32("happiness");
                int? ene = HttpContext.Session.GetInt32("energy");
                int? mea = HttpContext.Session.GetInt32("meals");
                string mess = HttpContext.Session.GetString("message");
                ViewBag.fullness = full;
                ViewBag.happiness = happ;
                ViewBag.energy = ene;
                ViewBag.meals = mea;
                ViewBag.message = mess;
            }
            return View("Dojo");
        }
        [HttpGet]
        [Route("feed")]
        public IActionResult feed(){
            Random x = new Random();
            if(x.Next(0,4)==3){
                int? mea = HttpContext.Session.GetInt32("meals");
                mea--;
                string mess = "I don't like it!! so you wasted meals!";
                HttpContext.Session.SetInt32("meals",(int)mea);
                HttpContext.Session.SetString("message",mess);
            }
            else{
                int? mea = HttpContext.Session.GetInt32("meals");
                mea--;
                HttpContext.Session.SetInt32("meals",(int)mea);
                int newfull = x.Next(5,11);
                int? full = HttpContext.Session.GetInt32("fullness");
                int temp = (int)full + newfull;
                string mess ="Consumed 1 meal, and gained " + newfull +" fullness!";
                HttpContext.Session.SetInt32("fullness",temp);
                HttpContext.Session.SetString("message",mess);
            }
            return RedirectToAction("dojodachi");
            // HttpContext.Session.SetObjectAsJson("domo",temp);
            // return Json(temp);
        }
        [HttpGet]
        [Route("work")]
        public IActionResult work(){
            Random x = new Random();
            int? ene = HttpContext.Session.GetInt32("energy");
            ene-=5;
            int rand = x.Next(1,4);
            int? mea = HttpContext.Session.GetInt32("meals");
            mea += rand;
            string mess ="Consumed 5 energy, but gained " + rand +" meals!";
            HttpContext.Session.SetInt32("energy", (int)ene);
            HttpContext.Session.SetInt32("meals", (int)mea);
            HttpContext.Session.SetString("message",mess);
            return RedirectToAction("dojodachi");
        }
        [HttpGet]
        [Route("sleep")]
        public IActionResult sleep(){
            int? ene = HttpContext.Session.GetInt32("energy");
            ene+=15;
            int? full = HttpContext.Session.GetInt32("fullness");
            full-=5;
            int? happ = HttpContext.Session.GetInt32("happiness");
            happ -=5; 
            string mess ="Consumed 5 fullness & 5 happiness but gained 15 energy!";
            HttpContext.Session.SetString("message",mess);
            HttpContext.Session.SetInt32("energy",(int)ene);
            HttpContext.Session.SetInt32("fullness",(int)full);
            HttpContext.Session.SetInt32("happiness",(int)happ);
            return RedirectToAction("dojodachi");
        }
        [HttpGet]
        [Route("play")]
        public IActionResult play(){
            Random x = new Random();
            int? ene = HttpContext.Session.GetInt32("energy");
            ene-=5;
            int? happ = HttpContext.Session.GetInt32("happiness");
            int rand = x.Next(5,11);
            happ+= rand;
            HttpContext.Session.SetInt32("energy",(int)ene);
            HttpContext.Session.SetInt32("happiness",(int)happ);
            string mess ="Consumed 5 energy but gained"+rand+"energy!";
            HttpContext.Session.SetString("message",mess);
            return RedirectToAction("dojodachi");
        }
    }
}