using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using CMS.ViewModel;
using AutoMapper;

namespace CMS.Controllers
{
	public class OrdersController : Controller
    {
		//var usrDTO = dal.Get(name, pwd);
		// userDTO -- User
		// user --- Uservm
		////UserDTO和User自动映射
		//var rtv = Mapper.Map<User>(usrDTO);
		//return rtv;
		private readonly CMSEntities8 content = new CMSEntities8();
		public List<Ordersvm> getOrders(int uid, int oid, int pid, int date)
		{
			var orders = content.getdata(uid, oid, pid, date).ToList();
			foreach (var item in orders)
			{
				var orderslistvm = Mapper.Map<Ordersvm>(item);
			}
			var list = Mapper.Map<List<Ordersvm>>(orders);
			return list;

		}
		// GET: Orders
		public ActionResult OrdersView()
		{
			if (Session["userid"] != null)
			{
				List<SelectListItem> df = new List<SelectListItem>();
				df.Add(new SelectListItem { Text = "-Select-", Value = "0", Selected = true });
				df.Add(new SelectListItem { Text = "Within a day", Value = "1" });
				df.Add(new SelectListItem { Text = "Within 7 days", Value = "2" });
				df.Add(new SelectListItem { Text = "Within a month", Value = "3" });
				df.Add(new SelectListItem { Text = "Within 6 months", Value = "4" });
				ViewBag.dateFilter = df;
				int userid = (int)Session["userid"];
				//var ordersDetail = content.getdata(userid, -1, -1, 0).ToList();
				var ordersDetail = getOrders(userid, -1, -1, 0);
				return View("OrdersView", ordersDetail);
			}
			else
			{
				return View("~/Views/LoginPage/LoginPageView.cshtml");
			}
			
		}
		[HttpPost]
		public ActionResult OrdersView(int dateFilter)
		{
			List<SelectListItem> df = new List<SelectListItem>();
			df.Add(new SelectListItem { Text = "-Select-", Value = "0", Selected = true });
			df.Add(new SelectListItem { Text = "Within a day", Value = "1" });
			df.Add(new SelectListItem { Text = "Within 7 days", Value = "2" });
			df.Add(new SelectListItem { Text = "Within a month", Value = "3" });
			df.Add(new SelectListItem { Text = "Within 6 months", Value = "4" });
			ViewBag.dateFilter = df;
			//var ordersDetail = content.getdata(1, -1, -1,dateFilter).ToList();
			var orders = getOrders(1, -1, -1, dateFilter);
			return View("OrdersView",orders);
		}
		[HttpPost]
		public ActionResult OrdersViewProductID(string productID)
		{
			List<SelectListItem> df = new List<SelectListItem>();
			df.Add(new SelectListItem { Text = "-Select-", Value = "0", Selected = true });
			df.Add(new SelectListItem { Text = "Within a day", Value = "1" });
			df.Add(new SelectListItem { Text = "Within 7 days", Value = "2" });
			df.Add(new SelectListItem { Text = "Within a month", Value = "3" });
			df.Add(new SelectListItem { Text = "Within 6 months", Value = "4" });
			ViewBag.dateFilter = df;
			int pid = -1;
			if(productID != null)
			{
				pid = Convert.ToInt32(productID);
			}
			else
			{
				pid = -1;
			}
			//var ordersDetail = content.getdata(1, -1, pid,0).ToList();
			var ordersDetail = getOrders(1, -1, pid, 0);
			return View("OrdersView", ordersDetail);
		}
		[HttpPost]
		public ActionResult OrdersViewOrderID(string orderID)
		{
			List<SelectListItem> df = new List<SelectListItem>();
			df.Add(new SelectListItem { Text = "-Select-", Value = "0", Selected = true });
			df.Add(new SelectListItem { Text = "Within a day", Value = "1" });
			df.Add(new SelectListItem { Text = "Within 7 days", Value = "2" });
			df.Add(new SelectListItem { Text = "Within a month", Value = "3" });
			df.Add(new SelectListItem { Text = "Within 6 months", Value = "4" });
			ViewBag.dateFilter = df;
			int oid = -1;
			if (orderID != null) {
				oid = Convert.ToInt32(orderID);
			}else
			{
				oid = -1;
			}
			//var ordersDetail = content.getdata(1, oid, -1,0).ToList();
			var ordersDetail = getOrders(1, oid, -1, 0);
			return View("OrdersView", ordersDetail);
		}
		ModelServices ms = new ModelServices();
		[HttpGet]
		public JsonResult Updateorder(int id)
		{
			bool result = false;
			try
			{
				result = ms.UpdateOrders(id);
			}
			catch
			{
			}
			return Json(new { result }, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public JsonResult Deleteorder(int id)
		{
			bool result = false;
			try
			{
				result = ms.DeleteOrder(id);
			}
			catch
			{
			}
			return Json(new { result }, JsonRequestBehavior.AllowGet);
		}
	}
	
	public class OrdersModel
	{
		public string SelectedItem { get; set; }
		public IEnumerable<SelectListItem> dateFilter { get; set; }
	}
	public class ModelServices : IDisposable
	{
		private readonly CMSEntities8 cms = new CMSEntities8();

		public bool UpdateOrders(int id)
		{
			int a = id;
			try
			{
				var order = cms.Orders.Where(x => x.orderID == a).FirstOrDefault();
				var ordesvm = Mapper.Map<Ordersvm>(order);
				string st = ordesvm.ShippingStatus;
				if (st.Equals("shipping"))
				{
					order.ShippingStatus = "shipped";
				}
				else if (st.Equals("shipped"))
				{
					order.ShippingStatus = "shipping";
				}
				cms.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool DeleteOrder(int id)
		{
			int a = id;
			try
			{
				var order = cms.Orders.Where(x => x.orderID == a).FirstOrDefault();
				cms.Orders.Remove(order);
				cms.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void Dispose()
		{
			cms.Dispose();
		}
	}
}