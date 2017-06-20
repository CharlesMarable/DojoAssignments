using Bank.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Bank.Controllers{
    public class RegisterController : Controller{
        private BankContext _context;

        public RegisterController(BankContext context){
            _context = context;
        }
        

        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.errors = new List<string>();
            return View();
        }
    }
}