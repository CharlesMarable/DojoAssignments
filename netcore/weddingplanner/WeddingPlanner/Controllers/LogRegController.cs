using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers{
    public class LogRegController : Controller{
        private WeddingContext _context;

        public LogRegController(WeddingContext context){
            _context = context;
        }

        //Render Login and Registration Homepage
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }

        //Register New User - Write into DB and save UserId in session
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Register user, User NewUser)
        {
            TryValidateModel(user);
            ViewBag.errors = ModelState.Values;
    
            if (ModelState.IsValid){
                User ThisUser = _context.User.SingleOrDefault(u => u.Email == user.Email);
                if (ThisUser == null){
                _context.Add(NewUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", NewUser.UserId);
                ViewBag.InSession = ThisUser;
                return RedirectToAction("Dashboard", "WP");
                } else {
                    TempData["error"] = "Email already in use";
                }
            }

            return View("Index");
        }

        //Login User - Validate input against DB and save UserId in session
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login user)
        {
            TryValidateModel(user);
            ViewBag.errors = ModelState.Values;

            User ThisUser = _context.User.SingleOrDefault(u => u.Email == user.Email);
            if (ThisUser != null){
                if (ThisUser.Password == user.Password){
                    HttpContext.Session.SetInt32("UserId", ThisUser.UserId);     
                    return RedirectToAction("Dashboard", "WP");
                }
            } else {
                TempData["error"] = "Invalid Email/Password combination";
            }

            return View("Index");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LogReg");
        }
        
    }
}