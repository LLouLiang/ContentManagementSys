using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using System.Drawing;


namespace CMS.Controllers
{

    

    public class ColorController : Controller
    {
		private readonly CMSEntities8 content = new CMSEntities8();
		// GET: Color
		public ActionResult ColorView()
        {
			
			if (Session["userid"] != null)
			{
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
				var allColor = content.getProColor(userid, -1, -1, -1).ToList();
				return View("ColorView", allColor);
			}
			else
			{
				return View("~/Views/LoginPage/LoginPageView.cshtml");
			}
        }

        [HttpPost]
        public ActionResult ColorView(string mainID, string subID)
        {


            
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
                var p2 = content.getProColor(userid, -1, categoryid, -1).ToList();
                return View("ColorView", p2);
            }
            else if (subID == "0" && mainID == "0")
            {
                //int categoryid = Convert.ToInt32(subID);
                var p3 = content.getProColor(userid, -1, -1, -1).ToList();
                return View("ColorView", p3);
            }
            else
            {
                int categoryid = Convert.ToInt32(subID);
                var p4 = content.getProColor(userid, categoryid,-1, -1).ToList();
                return View("ColorView", p4);
            }
            
        }
        [HttpPost]
       public ActionResult ColorsByProID( string productID)
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
            int pid = Convert.ToInt32(productID);
            var p4 = content.getProColor(userid, -1, -1, pid).ToList();
            return View("ColorView", p4);
        }



        ModelService ms = new ModelService();

        [HttpGet]
        public JsonResult UpdateColor(int id, string Colors)
        {
            bool result = false;
            try
            {
                result = ms.Updatecolors(id, Colors);
            }
            catch
            {
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
  

    public class ModelService : IDisposable
    {
        private readonly CMSEntities8 content = new CMSEntities8();

		Functions f = new Functions();
        public bool Updatecolors(int id, string Colors)
        {
            int a = id;
            string input = Colors;
            string[] newcolor = Colors.Split('/');
            int lenght= newcolor.Length;
                var product = content.Products.Where(x => x.productID == a).FirstOrDefault();
            //string st = product.Colors;
            var count = 0;
                foreach (var x in newcolor) {
                if (f.IsAColor(x))
                {
                    count++;
                    //return true; }
                }
                else
                {
                    count--;
                    //return false; }
                 }
                }
            if (count == lenght)
            {
                product.Colors = input;
                content.SaveChanges();
                return true;
            }

            else
                return false;
         
        }
        public void Dispose()
        {
            content.Dispose();
        }
    }
    public class Functions
    {
        public bool IsAColor(string colorName)
        {
            Color c = Color.FromName(colorName);
            if (c.IsKnownColor)
                return true;
            return false;
        }
    }
}