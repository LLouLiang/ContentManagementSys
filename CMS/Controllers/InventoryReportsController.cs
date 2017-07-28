using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CMS.ViewModel;

namespace CMS.Controllers
{
    public class InventoryReportsController : Controller
    {
		// GET: InventoryReports
		private readonly CMSEntities8 content = new CMSEntities8();
		public List<SalesInventoryvm> getInventory(int number,string name)
		{
			var inventory = content.getInventoryReports(number, name).ToList();
			var inventoryvm = Mapper.Map<List<SalesInventoryvm>>(inventory);
			return inventoryvm;
		}
		public ActionResult InventoryReports()
        {
			if (Session["userid"] != null)
			{
				string first = "default";
				var inventoryreport = getInventory(-1, first); //content.getInventoryReports(-1, first).ToList();
				return View("InventoryReports", inventoryreport);
			}
			else
			{
				return View("~/Views/LoginPage/LoginPageView.cshtml");
			}
		}
		[HttpPost]
		public ActionResult InventoryReportsPName(string pname)
		{
			var inventoryreport = getInventory(-1, pname);// content.getInventoryReports(-1, pname).ToList();
			return View("InventoryReports",inventoryreport);
		}
		[HttpPost]
		public ActionResult InventoryReportsPNumber(string pid)
		{
			string pname = "default";
			int pnumber = Convert.ToInt32(pid);
			var inventoryreport = getInventory(pnumber, pname); //content.getInventoryReports(pnumber, pname).ToList();
			return View("InventoryReports", inventoryreport);
		}
		[HttpGet]
		public JsonResult InventoryReportsView(string productID)
		{
			bool result = false;
			CMSEntities8 content = new CMSEntities8();
			int ProductID = Convert.ToInt32(productID);
			var views = content.getInventoryReportsView(ProductID).ToList();
			var inventoryvm = Mapper.Map<List<SalesInventoryvm>>(views);
			string pid = "";
			string pname = "";
			string manufacturerName = "";
			string size = "";
			string color = "";
			string categoryid = "";
			string uniteprice = "";
			string unitinstock = "";
			foreach(var item in inventoryvm)
			{
				pid = item.productID.ToString();
				pname = item.productName;
				manufacturerName = item.manufacturerName;
				size = item.Sizes;
				color = item.Colors;
				categoryid = item.categoryID.ToString();
				uniteprice = item.UnitPrice.ToString();
				unitinstock = item.unitsInStock.ToString();
			}
			if (views.ToString().Length != 0) {
				result = true;
			}
			return Json(new { result,pid,pname,manufacturerName,size,color,categoryid,uniteprice,unitinstock}, JsonRequestBehavior.AllowGet);
		}
    }
}