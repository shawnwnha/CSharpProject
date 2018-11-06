using Microsoft.AspNetCore.Mvc;
namespace netcore1.Controllers{
    public class firstController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult main(){
            ViewBag.name ="Shawn Nha 1991 06 21";
            return View("main");
        }
        [HttpGet]
        [Route("projects")]
        public IActionResult projects(){
            ViewBag.killa = "Hello Hello!";
            return View("index");
        }
        [HttpGet]
        [Route("contact/{name}")]
        public IActionResult contactName(string name){
            ViewBag.name = name;
            return View("contact");
        }
        [HttpPost]
        [Route("posting")]
        public IActionResult posting(string name, string email, string message){
            return RedirectToAction("posted", new {_name= name, _email = email, _message = message});
        }
        [HttpGet]
        [Route("posted")]
        public IActionResult posted(string _name, string _email, string _message){
            ViewBag.name = _name;
            ViewBag.email = _email;
            ViewBag.message = _message;
            return View("posted");
        }
        
        [HttpGet]
        [Route("contact")]
        public IActionResult contact(){
            return RedirectToAction("contactName", new { name = "shawn" });
        }

        [HttpGet]
        [Route("razor")]
        public IActionResult razorPractice(){
            return View("razor");
        }
    }
}