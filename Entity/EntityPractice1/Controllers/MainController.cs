using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;  // to use controller
using EntityPractice1.Models; // to use Models 
using Microsoft.AspNetCore.Http; // to use session
using Microsoft.EntityFrameworkCore;
using System.Linq;
// Other usings
 
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
        List<Person> AllUsers = _context.Users.ToList();
        return View();
    }

    [HttpGet]
    [Route("one")]
    public IActionResult One()
    {
        List<Person> AllUsers = _context.Users.Where(data =>data.Age == 26).ToList();
        return View();
    }

    [HttpGet]
    [Route("one/{Age}")]
    public IActionResult One(int Age)
    {
        Person OneUser = _context.Users.SingleOrDefault(data => data.Age == Age);
        return View();
    }

    [HttpGet]
    [Route("create")]
    public IActionResult Create(){
        Person newPerson = new Person(){
            Name = "Michael",
            Email = "Michael@Jackson.com",
            Password = "123123123", 
            Age = 45
        };
        _context.Users.Add(newPerson);
        _context.SaveChanges();
        return View();
    }

    [HttpGet]
    [Route("update")]
    public IActionResult Update(){
        Person OneUser = _context.Users.SingleOrDefault(data =>data.Age ==26);
        OneUser.Name = "SHAWNKING";
        _context.SaveChanges();
        return View();
    }

    [HttpGet]
    [Route("remove")]
    public IActionResult Remove(){
        Person OneUser = _context.Users.SingleOrDefault(data =>data.Age ==45);
        _context.Users.Remove(OneUser);
        _context.SaveChanges();
        return View();
    }
}