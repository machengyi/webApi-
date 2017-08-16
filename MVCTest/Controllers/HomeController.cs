using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCTest.Commen;
using weiapi练习.Models;


namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        public JsonResult AddUser(int UserID,string UserName,string UserEmail)
        {
            return "".ToJsonResult();
        }

        public JsonResult GetUser(string userName, int? userID) 
        {
            List<Users> data = new List<Users>();   
            if(userName != null && userName != "" && userID != null && userID != 0)
            {
                data = new weiapi练习.Controllers.UserController().GetUserByNameAndID(userName, (int)userID).ToList();
            }
            else if (userID != null&&userID!=0)
            {
                var dataByID = new weiapi练习.Controllers.UserController().GetUserByID((int)userID);
                data.Add(dataByID);                   
            }
            else if (string.IsNullOrWhiteSpace(userName))
            {
                 data = new weiapi练习.Controllers.UserController().Get().ToList();
            }
            else if (!string.IsNullOrWhiteSpace(userName))
            {
                 data = new weiapi练习.Controllers.UserController().GetUserByName(userName).ToList();
            }

            return data.ToJsonResult();
        }
    }
}