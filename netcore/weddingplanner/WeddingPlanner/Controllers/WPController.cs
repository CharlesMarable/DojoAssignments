using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers{
    public class WPController : Controller{
        private WeddingContext _context;

        public WPController(WeddingContext context){
            _context = context;
        }

        //Render Wedding Planner Dashboard Page, populate with DB 
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            ViewBag.InSession = new List<string>();
            ViewBag.AllWeddings = new List<string>();

            int? SessionId = HttpContext.Session.GetInt32("UserId");
            if (SessionId == null){
                TempData["error"] = "Must be logged in to view this page";
                return RedirectToAction("Index", "LogReg");
            }
            User ThisUser = _context.User.SingleOrDefault(u => u.UserId == (int)SessionId);
            ViewBag.InSession = ThisUser;

            List<Wedding> AllWeddings = _context.Wedding
                                                    .Include(wed => wed.Guests)
                                                    .ToList();
            ViewBag.AllWeddings = AllWeddings;


            return View("Dashboard");
        }

        //Delete existing wedding event
        [HttpGet]
        [Route("Delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
            Wedding ThisWedding = _context.Wedding.SingleOrDefault(w => w.WeddingId == WeddingId);
            _context.Wedding.Remove(ThisWedding);
            _context.SaveChanges();
            
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("AddGuest/{WeddingId}")]
        public IActionResult AddGuest(int WeddingId)
        {
            int? SessionId = HttpContext.Session.GetInt32("UserId");
            User ThisUser = _context.User.Where(u => u.UserId == SessionId).SingleOrDefault();
            Wedding ThisWedding = _context.Wedding.Where(w => w.WeddingId == WeddingId).SingleOrDefault();
            Guest NewGuest = new Guest{
                User = ThisUser,
                Wedding = ThisWedding
            };
            _context.Add(NewGuest);
            _context.SaveChanges();

            
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("RemoveGuest/{WeddingId}")]
        public IActionResult RemoveGuest(int WeddingId)
        {
            int? SessionId = HttpContext.Session.GetInt32("UserId");
            // User ThisUser = _context.User.Where(u => u.UserId == SessionId).SingleOrDefault();
            Wedding ThisWedding = _context.Wedding.Where(w => w.WeddingId == WeddingId).Include(wed => wed.Guests).SingleOrDefault();
            Guest ThisGuest  = _context.Guest.Where(g => g.UserId == SessionId).SingleOrDefault(g => g.WeddingId == WeddingId);
            _context.Remove(ThisGuest);
            _context.SaveChanges();

            
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            ViewBag.errors = new List<string>();

            int? SessionId = HttpContext.Session.GetInt32("UserId");
            if (SessionId == null){
                TempData["error"] = "Must be logged in to view this page";
                return RedirectToAction("Index", "LogReg");
            }
            return View("New");
        }

        [HttpPost]
        [Route("NewWedding")]
        public IActionResult NewWedding(WeddingVal wed, Wedding NewWed)
        {

            TryValidateModel(wed);
            ViewBag.errors = ModelState.Values;
            int? SessionId = HttpContext.Session.GetInt32("UserId");
            User ThisUser = _context.User.Where(u => u.UserId == SessionId).SingleOrDefault();
    
            if (ModelState.IsValid){
                NewWed.Creator = ThisUser;
                _context.Add(NewWed);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("New");
        }

        [HttpGet]
        [Route("Show/{WeddingId}")]
        public IActionResult Show(int WeddingId)
        {
            ViewBag.ThisWedding = new List<string>();

            int? SessionId = HttpContext.Session.GetInt32("UserId");
            if (SessionId == null){
                TempData["error"] = "Must be logged in to view this page";
                return RedirectToAction("Index", "LogReg");
            }

            Wedding ThisWedding = _context.Wedding.Where(w => w.WeddingId == WeddingId)
                                                                                .Include(w => w.Guests)
                                                                                .ThenInclude(u => u.User)
                                                                                .SingleOrDefault();
            ViewBag.ThisWedding = ThisWedding;
            return View("Show");
        }

    }
}