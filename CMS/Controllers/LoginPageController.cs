using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using CMS.ViewModel;
using System.Web.Security;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace CMS.Controllers
{
    public class LoginPageController : Controller
	{
		private readonly CMSEntities8 content = new CMSEntities8();
		// GET: LoginPage
		public ActionResult LoginPageView()
        {
			Uservm lmvm = new Uservm();
			if (Request.Cookies["Login"] != null)
			{
				lmvm.LoginID = Convert.ToInt32(Request.Cookies["Login"].Values["LoginID"]);
			}
			Session.Clear();
			Session.Abandon();
			Session.RemoveAll();
			this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
			this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			this.Response.Cache.SetNoStore();
			return View(lmvm);
        }
		public Uservm getloginModel(Uservm us)
		{ 
			var user = new User();
			user = content.Users.Where(x => x.LoginID == us.LoginID).FirstOrDefault();
			var uservm = Mapper.Map<Uservm>(user);
			return uservm;
		}

        [HttpPost]
        public ActionResult LoginPageView(Uservm us)
        {
			try
			{
				var loginid = us.LoginID;
				var pwd = us.LoginPwd;
				bool result = (from s in content.Users
							   where s.LoginID == loginid && s.LoginPwd == pwd
							   select s).Any();

				if (result == true)
				{
					var user = getloginModel(us);
					int userid = user.userID;
					string userrole = user.UserRole;
					string userName = user.userName;
					FormsAuthentication.SetAuthCookie(us.LoginID.ToString(), us.rememberMe);
					Session["userrole"] = userrole;
					Session["userid"] = userid;
					Session["name"] = userName;
					if (user.rememberMe)
					{
						HttpCookie myLoginCookie = new HttpCookie("Login");
						myLoginCookie.Values.Add("LoginID", user.LoginID.ToString());
						myLoginCookie.Expires = DateTime.Now.AddSeconds(3600);
						Response.Cookies.Add(myLoginCookie);
					}
					return RedirectToAction("Products", "ProductPage");
				}
				else
				{
					return RedirectToAction("LoginPageView", "LoginPage");
				}
			}
			catch
			{
				return View(us);
			}
            

        }
    }
}
