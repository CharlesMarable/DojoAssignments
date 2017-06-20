using Restauranter.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Restauranter.Controllers{
    public class ReviewsController : Controller{
        private RestaurantContext _context;

        public ReviewsController(RestaurantContext context){
            _context = context;
        }
        

        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("WriteReview")]
        public IActionResult WriteReview(Reviews rev){
            // Reviews NewReview = new Reviews{Reviewer = reviewer, Restaurant = restaurant, Review = review, VisitDate = visitdate, Stars = stars};
            TryValidateModel(rev);
            ViewBag.errors = new List<string>();
            ViewBag.errors = ModelState.Values;

            if (ModelState.IsValid){
                rev.RCreatedAt = DateTime.Now;
                _context.Add(rev);
                _context.SaveChanges();
                return RedirectToAction("Results");
            }

            return View("Index");
        }

        [HttpGet]
        [Route("Results")]
        public IActionResult Results(){
            ViewBag.AllReviews = new List<string>();
            List<Reviews> AllReviews = _context.reviews.OrderByDescending(r => r.RCreatedAt).ToList();
            ViewBag.AllReviews = AllReviews;
            return View("Results");
        }
    }
}