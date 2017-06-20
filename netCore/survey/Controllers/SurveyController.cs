using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

             return View();
        }
        [HttpPost]
        [Route("results")]
        public IActionResult Results(string name, string location, string language, string comment)
        {
            System.Console.WriteLine("__________________________");
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comment = comment;
            return View("Results");
    
        }

    }
}