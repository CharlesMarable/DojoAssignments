using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class TimeControl : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
             return View();
        }
    }
}