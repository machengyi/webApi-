using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCTest.Commen;
using System.Web.Mvc;
using System.Web.Security;
using weiapi练习.Models;
using NFine.Code;
using NFine.Web;

namespace MVCTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult Login(string Account, string Password,string code)
        {
            try
            {
                if (Session["nfine_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["nfine_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }
                if (!string.IsNullOrWhiteSpace(Account) || !string.IsNullOrWhiteSpace(Password))
                {
                    List<StaffTable> userInfo = new List<StaffTable>();
                    userInfo = new weiapi练习.Controllers.UsersInfoController().UserInfo(Account, Password);
                    if (userInfo.Count() > 0 && userInfo[0] != null)
                    {
                        Session["UserName"] = userInfo[0].Nickname;
                        return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
                    }
                    else
                    {
                        return Content(new AjaxResult { state = ResultType.error.ToString(), message = "账号或密码不正确。" }.ToJson());

                    }
                }
                else
                {
                    return Content(new AjaxResult { state = ResultType.error.ToString(), message = "请输入账号和密码。" }.ToJson());

                }
            }
            catch (Exception ex)
            {
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
           
        }
        public void Logout()
        {
            //FormsAuthentication.SignOut();
            Session.Remove("UserName");
            Response.Redirect("/Login/Index");
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
    }
}