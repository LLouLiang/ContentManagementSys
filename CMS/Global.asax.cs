using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CMS.Models;
using CMS.ViewModel;

namespace CMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			Mapper.Initialize( cfg=>
			{
				cfg.CreateMap<User,Uservm>().ReverseMap();
				cfg.CreateMap<getdata_Result, Ordersvm>().ReverseMap();
				cfg.CreateMap<Order, Ordersvm>().ReverseMap();
				cfg.CreateMap<getSalesReportsProductIdFilter_Result,SalesReportvm>().ReverseMap();
				cfg.CreateMap<getSalesReports_Result, SalesReportvm>().ReverseMap();
				cfg.CreateMap<getInventoryReports_Result, SalesInventoryvm>().ReverseMap();
				cfg.CreateMap<getInventoryReportsView_Result, SalesInventoryvm>().ReverseMap();
			}
				);
		}
		protected void Application_BeginRequest()
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
			Response.Cache.SetNoStore();
		}
	}
}
