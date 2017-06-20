using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using logandreg.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace logandreg.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.logErrors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("method")]
        public IActionResult RegSub(string fname, string lname, string email, string password, string passwordconf)
        {
            User NewUser = new User{fname = fname, lname = lname, email = email, password = password};
            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;
            if(ModelState.IsValid)
            {
                string QueryString = $"SELECT * FROM user WHERE email = '{email}';";
                Dictionary<string, object> myUser = _dbConnector.Query(QueryString).SingleOrDefault();
                if(myUser == null){
                    if(password == passwordconf){

                        string userinfo = $"INSERT INTO User(fname, lname, email, password, created_at) VALUES ('{fname}', '{lname}', '{email}', '{password}', NOW())";
                        _dbConnector.Execute(userinfo);
                        HttpContext.Session.SetInt32("id", (int)myUser["id"]);
                        return RedirectToAction("Success");
                    }
                    else{
                        TempData["warning"] = "Passwords do not match";
                    }
                }
                else{
                    TempData["warning"] = "Email already in database";
                }
            }
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult logSub(string email, string password)
        {
            string QueryString = $"SELECT * FROM user WHERE email = '{email}';";
            Dictionary<string, object> myUser = _dbConnector.Query(QueryString).SingleOrDefault();
            if(myUser != null && password != null){
                if((string)myUser["password"]== password){
                    HttpContext.Session.SetInt32("id", (int)myUser["id"]);
                    return RedirectToAction("Success");
                }
            }
            else{
                TempData["loginerror"] = "Invalid Name or Password";
                ViewBag.errors = new List<string>();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            ViewBag.CurrentUser = new List<string>();
            int? sessionid = HttpContext.Session.GetInt32("id");
            if(sessionid == null){
                TempData["warning"] = "Must be logged in to view this page";
                return RedirectToAction("Index");
            }
            string QueryString = $"SELECT * FROM user WHERE id = '{sessionid}';";
            Dictionary<string, object> myUser = _dbConnector.Query(QueryString).SingleOrDefault();
            ViewBag.CurrentUser = myUser;
            return View("Success");
        }
    }
}
