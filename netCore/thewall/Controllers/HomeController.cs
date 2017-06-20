using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using thewall.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace thewall.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();

            return View();
        }

        [HttpPost]
        [Route("method")]
        public IActionResult RegSub(string fname, string lname, string email, string password, string passwordconf)
        {
            User NewUser = new User{fname = fname, lname = lname, email = email, password = password};
            TryValidateModel(NewUser);
            ViewBag.CurrentUser = new List<string>();
            ViewBag.errors = new List<string>();
            ViewBag.AllMessages = new List<string>();
            ViewBag.errors = ModelState.Values;
            if(ModelState.IsValid)
            {
                string QueryString = $"SELECT * FROM users WHERE email = '{email}';";
                Dictionary<string, object> myUser = _dbConnector.Query(QueryString).SingleOrDefault();
                if(myUser == null){
                    if(password == passwordconf){

                        string userinfo = $"INSERT INTO users(fname, lname, email, password, UCreatedAt) VALUES ('{fname}', '{lname}', '{email}', '{password}', NOW())";
                        _dbConnector.Execute(userinfo);
                        string idString = $"SELECT * FROM users WHERE email = '{email}';";
                        Dictionary<string, object> Userid = _dbConnector.Query(idString).SingleOrDefault();
                        HttpContext.Session.SetInt32("UserId", (int)Userid["UserId"]);
                        return RedirectToAction("TheWall");
                    }
                    else{
                        TempData["warning"] = "Passwords do not match";
                    }
                }
                else{
                    TempData["warning"] = "Email already in database";
                }
            }
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult logSub(string email, string password)
        {
            string QueryString = $"SELECT * FROM users WHERE email = '{email}';";
            Dictionary<string, object> myUser = _dbConnector.Query(QueryString).SingleOrDefault();
            if(myUser != null && password != null){
                if((string)myUser["password"]== password){
                    HttpContext.Session.SetInt32("UserId", (int)myUser["UserId"]);
                    return RedirectToAction("TheWall");
                }
            }
            else{
                TempData["loginerror"] = "Invalid Name or Password";
                ViewBag.errors = new List<string>();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("WriteMessage")]
        public IActionResult WriteMessage(string message)
        {
            int? sessionid = HttpContext.Session.GetInt32("UserId");
            string UserString = $"SELECT * FROM users WHERE UserId = '{sessionid}';";
            Dictionary<string, object> myUser = _dbConnector.Query(UserString).SingleOrDefault();
            ViewBag.CurrentUser = myUser;
            Message NewMessage = new Message{message = message};
            TryValidateModel(NewMessage);
            ViewBag.errors = ModelState.Values;
            if(ModelState.IsValid){
                string QueryString = $"INSERT INTO messages(UserId, message, MCreatedAt) VALUES ('{sessionid}','{message}', NOW())";
                _dbConnector.Execute(QueryString);
                return RedirectToAction("TheWall");
            }
            return View("TheWall");
        }

        [HttpPost]
        [Route("WriteComment/{MessageId}")]
        public IActionResult WriteComment(string comment, string MessageId)
        {
            int? sessionid = HttpContext.Session.GetInt32("UserId");
            string UserString = $"SELECT * FROM users WHERE UserId = '{sessionid}';";
            Dictionary<string, object> myUser = _dbConnector.Query(UserString).SingleOrDefault();
            ViewBag.CurrentUser = myUser;
            Comment NewComment = new Comment{comment = comment};
            TryValidateModel(NewComment);
            ViewBag.errors = ModelState.Values;
            if(ModelState.IsValid){
                string QueryString = $"INSERT INTO comments(UserId, comment, MessageId, CCreatedAt) VALUES ('{sessionid}','{comment}', '{MessageId}', NOW())";
                _dbConnector.Execute(QueryString);
                return RedirectToAction("TheWall");
            }
            return View("TheWall");
        }

        [HttpGet]
        [Route("TheWall")]
        public IActionResult TheWall()
        {
            int? sessionid = HttpContext.Session.GetInt32("UserId");
            ViewBag.CurrentUser = new List<string>();
            ViewBag.AllMessages = new List<string>();
            ViewBag.AllComments = new List<string>();
            if(sessionid == null){
                TempData["warning"] = "Must be logged in to view this page";
                return RedirectToAction("Index");
            }
            string QueryString = $"SELECT * FROM users WHERE UserId = '{sessionid}';";
            Dictionary<string, object> myUser = _dbConnector.Query(QueryString).SingleOrDefault();
            string MessageString = $"SELECT messages.MessageId, users.fname, users.lname, messages.MCreatedAt, messages.message FROM messages JOIN users ON messages.UserId=users.UserId ORDER BY messages.MCreatedAt DESC";
            List<Dictionary<string, object>> AllMessages = _dbConnector.Query(MessageString);
            System.Console.WriteLine(AllMessages);
            string CommentString = $"SELECT comments.MessageId, users.fname, users.lname, comments.CCreatedAt, comments.comment FROM comments JOIN users ON comments.UserId=users.UserId JOIN messages ON comments.MessageId=messages.MessageId";
            List<Dictionary<string, object>> AllComments = _dbConnector.Query(CommentString);
            System.Console.WriteLine(AllComments);
            ViewBag.AllMessages = AllMessages;
            System.Console.WriteLine(ViewBag.AllMessages);
            ViewBag.AllComments = AllComments;
            ViewBag.CurrentUser = myUser;
            ViewBag.errors = new List<string>();
            return View("TheWall");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
