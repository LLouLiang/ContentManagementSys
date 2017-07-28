using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using System.Data;


namespace CMS.Controllers
{
    public class ProductPageController : Controller
    {
		private readonly CMSEntities8 content = new CMSEntities8();
        // GET: ProductPage
        public ActionResult Products()
		{ 	
			// old part
			//CMSEntities4 content = new CMSEntities4();
			if (Session["userid"] != null)
			{
				int userid = ((int)Session["userid"]);
				//int userid = 1;
				int cateid = -1;
				var p1 = content.getProByUserID(userid, cateid, -1).ToList();
				List<SelectListItem> maincat = new List<SelectListItem>();
				maincat.Add(new SelectListItem { Text = "-Select- the main category", Value = "0", Selected = true });
				maincat.Add(new SelectListItem { Text = "Men", Value = "1" });
				maincat.Add(new SelectListItem { Text = "Women", Value = "2" });

				ViewBag.mainID = maincat;

				List<SelectListItem> categories = new List<SelectListItem>();
				categories.Add(new SelectListItem { Text = "-Select-subcategory", Value = "0", Selected = true });
				var subcat = content.getCategoryIDs(-1);

				foreach (var item in subcat)
				{
					SelectListItem li = new SelectListItem();

					li.Value = item.id.ToString();
					li.Text = item.CategoryName;

					categories.Add(li);

				}
				ViewBag.subID = categories;


				return View("Products", p1);
			}else
			{
				return View("~/Views/LoginPage/LoginPageView.cshtml");
			}
				
		}
		[HttpGet]
		public JsonResult addAProduct(int userID,string productName,string manufacturerName, string size,string color, int categoryID,decimal price,int unitInStock)
		{
			int userid = Convert.ToInt32(userID);
			content.addProduct(userID,productName,manufacturerName,size,color,categoryID,price,unitInStock);
			return Json(null,JsonRequestBehavior.AllowGet);
		}
        [HttpPost]
        public ActionResult Products(string mainID, string subID)
        {
            //int userid = 1;
            int userid = ((int)Session["userid"]);
            List<SelectListItem> maincat = new List<SelectListItem>();
            maincat.Add(new SelectListItem { Text = "-Select- the main category", Value = "0", Selected = true });
            maincat.Add(new SelectListItem { Text = "Men", Value = "1" });
            maincat.Add(new SelectListItem { Text = "Women", Value = "2" });

            ViewBag.mainID = maincat;

            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Text = "-Select-subcategory", Value = "0", Selected = true });
            var subcat = content.getCategoryIDs(-1);

            foreach (var item in subcat)
            {
                SelectListItem li = new SelectListItem();
                li.Value = item.id.ToString();
                li.Text = item.CategoryName;

                categories.Add(li);

            }

            ViewBag.subID = categories;

            if (mainID == "1")
            {
                List<SelectListItem> categories1 = new List<SelectListItem>();
                categories1.Add(new SelectListItem { Text = "-Select-subcategory", Value = "0", Selected = true });
                var subcat1 = content.getCategoryIDs(1);

                foreach (var item in subcat1)
                {
                    SelectListItem li = new SelectListItem();
                    li.Value = item.id.ToString();
                    li.Text = item.CategoryName;

                    categories1.Add(li);

                }

                ViewBag.subID = categories1;

            }
            else if (mainID == "2")
            {
                List<SelectListItem> categories2 = new List<SelectListItem>();
                categories2.Add(new SelectListItem { Text = "-Select-subcategory", Value = "0", Selected = true });
                var subcat2 = content.getCategoryIDs(2);

                foreach (var item in subcat2)
                {
                    SelectListItem li = new SelectListItem();
                    li.Value = item.id.ToString();
                    li.Text = item.CategoryName;

                    categories2.Add(li);

                }

                ViewBag.subID = categories2;

            }
            if (subID == "0" && mainID != "0")
            {
                int categoryid = Convert.ToInt32(mainID);
                var p2 = content.getProByUserID(userid, categoryid, -1).ToList();
                return View("Products", p2);
            }
            else if (subID == "0" && mainID == "0")
            {
                //int categoryid = Convert.ToInt32(subID);
                var p3 = content.getProByUserID(userid, -1, -1).ToList();
                return View("Products", p3);
            }
            else
            {
                int categoryid = Convert.ToInt32(subID);
                var p4 = content.getProByUserID(userid, categoryid, -1).ToList();
                return View("Products", p4);
            }

        }


        [HttpPost]
        public ActionResult ProductViewProductID(string productID)
        {
            List<SelectListItem> maincat = new List<SelectListItem>();
            maincat.Add(new SelectListItem { Text = "-Select- the main category", Value = "0", Selected = true });
            maincat.Add(new SelectListItem { Text = "Men", Value = "1" });
            maincat.Add(new SelectListItem { Text = "Women", Value = "2" });

            ViewBag.mainID = maincat;

            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Text = "-Select-subcategory", Value = "0", Selected = true });
            var subcat = content.getCategoryIDs(-1);

            foreach (var item in subcat)
            {
                SelectListItem li = new SelectListItem();

                li.Value = item.id.ToString();
                li.Text = item.CategoryName;

                categories.Add(li);

            }
            ViewBag.subID = categories;
            int userid = ((int)Session["userid"]);
            if (String.IsNullOrEmpty(productID))
            {

                var p5 = content.getProByUserID(userid, -1, -1).ToList();
                return View("Products", p5);
            }
            else
            {
                int pid = Convert.ToInt32(productID);

                var p4 = content.getProByUserID(userid, -1, pid).ToList();
                return View("Products", p4);
            }
        }


        //    [HttpPost]
        //    public ActionResult ProductSub(string subID)
        //    {
        //        CMSEntities3 content = new CMSEntities3();

        //        //int userid = 1;
        //        int userid = ((int)Session["userid"]);
        //        List<SelectListItem> maincat = new List<SelectListItem>();
        //        maincat.Add(new SelectListItem { Text = "-Select- the main category", Value = "0", Selected = true });
        //        maincat.Add(new SelectListItem { Text = "Men", Value = "1" });
        //        maincat.Add(new SelectListItem { Text = "Women", Value = "2" });

        //        ViewBag.mainID = maincat;

        //        List<SelectListItem> categories = new List<SelectListItem>();
        //        categories.Add(new SelectListItem { Text = "-Select-subcategory", Value = "0", Selected = true });
        //        var subcat = content.getCategoryIDs(-1);

        //        foreach (var item in subcat)
        //        {
        //            SelectListItem li = new SelectListItem();
        //            li.Value = item.id.ToString();
        //            li.Text = item.CategoryName;

        //            categories.Add(li);

        //        }

        //        ViewBag.subID = categories;
        //        int categoryid = Convert.ToInt32(subID);
        //        var p2 = content.getProByUserID(userid, categoryid ).ToList();

        //        return View("Products", p2) ;
        //    }


        //}

        public class ProductModel
        {
            public IEnumerable<SelectListItem> subID;
            public IEnumerable<SelectListItem> mainID;
        }
    }
}