using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using weiapi练习.Manager;
using weiapi练习.Models;

namespace weiapi练习.Controllers
{
    public class UsersInfoController : Controller
    {
        // GET: UsersInfo
        public ActionResult Index()
        {
            return View();
        }
        public List<StaffTable> UserInfo(string AccountNum,string Password)
        {
            List<StaffTable> data = new List<StaffTable>();
            LoginData ld = new LoginData();
            data.Add(ld.UsersInfo(AccountNum, Password));
            return data;
        }
    }
}