using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankroll.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bankroll.Controllers
{
     public class SuccessController : Controller
{
    private BankContext _context;
 
    public SuccessController(BankContext context)
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
                ViewBag.alltrans = _context.Transactions.Where(user => user.userId == curruser);
            }
            return View("Success");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(int action)
        {
            int? curruser = HttpContext.Session.GetInt32("UserID");
            var sessionuser = _context.Users.SingleOrDefault(user => user.userId == curruser);
            if(sessionuser.balance + action >= 0)
            {
                Transactions NewTrans = new Transactions
                {
                    userId = (int)curruser,
                    action = action,
                    tcreatedAt = DateTime.Now
                };
                _context.Transactions.Add(NewTrans);
                Users RetrievedUser = _context.Users.SingleOrDefault(user => user.userId == curruser);
                RetrievedUser.balance += action;
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            else
            {
                TempData["error"] = "Cannot withdraw more than is in account!";
            }
        
            return RedirectToAction("Success");
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
