using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecom.Controllers
{
     public class EcomController : Controller
{
    private EcomContext _context;
 
    public EcomController(EcomContext context)
    {
        _context = context;
    }
 
        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            var curruser = HttpContext.Session.GetInt32("UserID");
            if(curruser == null)
            {
                return RedirectToAction("Index", "Bank");
            }
            else
            {
                ViewBag.errors = new List<string>();
                ViewBag.alltrans = new List<string>();
                ViewBag.curruser = _context.Users.SingleOrDefault(user => user.userId == curruser);
                // ViewBag.alltrans = _context.Transactions.Where(user => user.userId == curruser);
            }
            return View("Success");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Bank");
        }
    }
}
