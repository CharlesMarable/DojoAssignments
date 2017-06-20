using Bank.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Bank.Controllers{
    public class LoginController : Controller{
        private BankContext _context;

        public LoginController(BankContext context){
            _context = context;
        }
        

        [HttpGet]
        [Route("login")]
        public IActionResult Login(){
            ViewBag.errors = new List<string>();
            return View("index");
        }
    }
}