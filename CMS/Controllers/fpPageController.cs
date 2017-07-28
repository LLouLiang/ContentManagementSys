using CMS.Models;
using CMS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class fpPageController : Controller
    {
		private readonly CMSEntities8 content = new CMSEntities8();
		// GET: fpPage
		public ActionResult forgotPassword()
        {
			return View();
		}
		public Uservm getuser(Uservm uvm)
		{
			var user = new User();
			user = content.Users.Where(x => x.LoginID == uvm.LoginID).FirstOrDefault();
			user.LoginPwd = uvm.LoginPwd2;
			content.SaveChanges();
			var uservm = Mapper.Map<Uservm>(user);
			return uservm;
		}
		[HttpPost]
		public ActionResult forgotPassword(Uservm lm)
		{
			try
			{
				var user = getuser(lm);
				int uID = user.userID;
				System.Web.HttpContext.Current.Session["userLoginID"] = uID;
				return RedirectToAction("LoginPageView", "LoginPage");
			}
			catch
			{
				return View(lm);
			}
			
		}
    }
}