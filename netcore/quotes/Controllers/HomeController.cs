using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Mvc;

namespace quotes.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("method")]
        public IActionResult UserQuotes(string name, string quote)
        {
            // string username = name;
            // string userquote = quote;
            string userinfo = $"INSERT INTO User(name, quote, created_at) VALUES ('{name}', '{quote}', NOW())";
            System.Console.WriteLine(userinfo);
            DbConnector.Execute(userinfo);
            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes(){
            {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT name, quote, created_at FROM User ORDER BY created_at DESC");
            ViewBag.Quotes = AllUsers;
            return View("Quotes");
            }
        }
    }
}
