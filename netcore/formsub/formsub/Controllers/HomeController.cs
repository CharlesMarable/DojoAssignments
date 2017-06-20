using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

namespace formsub.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("method")]
        public IActionResult FormSub(string fname, string lname, int age, string email, string password)
        {
            User NewUser = new User{fname = fname, lname = lname, age = age, email = email, password = password};
            TryValidateModel(NewUser);
            ViewBag.errors = new List<string>();
            ViewBag.errors = ModelState.Values;
            if(ModelState.IsValid)
            {
                string userinfo = $"INSERT INTO UserForm(fname, lname, age, email, password, created_at) VALUES ('{fname}', '{lname}', '{age}', '{email}', '{password}', NOW())";
                DbConnector.Execute(userinfo);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
