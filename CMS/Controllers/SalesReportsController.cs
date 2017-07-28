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
    public class SalesReportsController : Controller
    {
		private readonly CMSEntities8 content = new CMSEntities8();
		public List<SalesReportvm> getSRByFilter(int number)
		{
			var salesReport = content.getSalesReportsProductIdFilter(number).ToList();
			var list = Mapper.Map<List<SalesReportvm>>(salesReport);
			return list;
		}
		// GET: SalesReports
		public ActionResult SalesReports()
        {
			if(Session["userid"]!= null)
			{
				var salesreport = getSRByFilter(-1);
				return View("SalesReports", salesreport);
			}else
			{
				return View("~/Views/LoginPage/LoginPageView.cshtml");
			}
			
		}

		[HttpPost]
		public ActionResult SalesReports(string productID)
		{
			int pid = -1;
			if (productID.Length==0)
			{
				 pid = -1;
			}
			else
			{
				pid = Convert.ToInt32(productID);
			}
			var salesReport = getSRByFilter(pid);
			return View("SalesReports",salesReport);
		}

		[HttpGet]
		public JsonResult SalesReportsView(string productID)
		{
			bool result = false;
			int ProductID = Convert.ToInt32(productID);
			var salesview = content.getSalesReports(ProductID).ToList();
			var sale = Mapper.Map<List<SalesReportvm>>(salesview);
			string pid = "" ;
			string pname="";
			string numleft = "";
			foreach (var item in sale)
			{
				pid = item.productID.ToString();
				pname = item.NumberSold.ToString();
				numleft = item.NumberLeftInStock.ToString();
			}
			if (salesview.ToString().Length != 0)
			{
				result = true;
			}
			return Json(new { result, pid, pname,numleft }, JsonRequestBehavior.AllowGet);
		}
	}
}