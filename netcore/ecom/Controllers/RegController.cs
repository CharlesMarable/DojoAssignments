using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecom.Controllers
{
     public class RegController : Controller
{
    private ecom.Models.EcomContext _context;
 
    public RegController(EcomContext context)
    {
        _context = context;
    }
 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            ViewBag.errors = ModelState.Values;
           if(ModelState.IsValid)
           {
               Users curruser = _context.Users.SingleOrDefault(use => use.email == model.email);
               if(curruser == null)
               {
                   Users NewUser = new Users
                    {
                    firstname = model.firstname,
                    lastname = model.lastname,
                    email = model.email,
                    password = model.password,
                    ucreatedAt = DateTime.Now,
                    
                    };
                    _context.Users.Add(NewUser);
                    _context.SaveChanges();
                    Users userid = _context.Users.SingleOrDefault(user => user.email == model.email);
                    HttpContext.Session.SetInt32("UserID", (int)userid.userId);
                    ViewBag.userid = userid;
                    return RedirectToAction("Success", "Success");
               }
           }
            return View("Index");
        }
        [HttpGet]
        [Route("tologin")]
        public IActionResult tologin()
        {
            ViewBag.errors = new List<string>();
            return View("login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(string email, string password)
        {
             ViewBag.errors = new List<string>();
             Users curruser = _context.Users.SingleOrDefault(user => user.email == email);
             System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
             System.Console.WriteLine(curruser);
             if(curruser != null && password != null)
             {
                 System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
                 if((string)curruser.password == password)
                 {
                     System.Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^");
                    Users userid = _context.Users.SingleOrDefault(user => user.email == email);
                    HttpContext.Session.SetInt32("UserID", (int)userid.userId);
                    return RedirectToAction("Success", "Success");
                 }
             }
            return View();
        }
    }

}
