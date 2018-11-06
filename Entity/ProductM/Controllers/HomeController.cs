using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductM.Models;

namespace ProductM.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext _context;
        public HomeController(HomeContext context){
            _context = context;
        }
        [HttpGet]
        [Route("products/new")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("products/new")]
        public IActionResult SubmitProduct(Product product){
            if(ModelState.IsValid){
                product.Created_at = DateTime.Now;
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View("Index");
            }
        }
        [HttpGet]
        [Route("categories/new")]
        public IActionResult Index2()
        {
            return View("Category");
        }
        [HttpPost]
        [Route("categories/new")]
        public IActionResult SubmitCategory(Category category){
            if(ModelState.IsValid){
                category.Created_at = DateTime.Now;
                _context.categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index2");
            }
            else{
                return View("Category");
            }
        }
        [HttpGet]
        [Route("products/{id}")]
        public IActionResult ShowProducts(int id)
        {
            Product x = _context.products.Include(data => data.Categories).ThenInclude(c => c.Category).SingleOrDefault(data => data.ProductId == id);
            List<Category> y = _context.categories.ToList();
            ViewBag.Product = x;
            ViewBag.C = y;
            return View("Product");
        }
        [HttpPost]
        [Route("products/{id}")]
        public IActionResult AddCategory(int id, int Cid){
            ProCat z = new ProCat{
                ProductId = id,
                CategoryId = Cid
            };
            _context.product_category.Add(z);
            _context.SaveChanges();
            return RedirectToAction("ShowProducts");
        }
    }
}
