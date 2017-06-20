using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers

{
    public class PortController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {     
   
            return View();
       
        }

        [HttpGet]
        [Route("Projects")]
        public IActionResult Projects()
        {     
   
            return View("Projects");
       
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {     
   
            return View("Contact");
       
        }   
    }
}