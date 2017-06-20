using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class CallingController : Controller
    {
        [HttpGet]
        [Route("{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult DisplayInt(string FirstName, string LastName, int Age, string FavColor)
        {
            return Json(new {FirstName = FirstName, LastName = LastName, Age = Age, FavoriteColor = FavColor});
        }
    }
}