
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;


namespace CMS.Controllers
{
    public class SizeController : Controller
	{ 
		private readonly CMSEntities8 content = new CMSEntities8();
		// GET: Size
		public ActionResult SizeView()
        {
			if(Session["userid"]!= null)
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
                var allpro = content.getProSize(userid, -1, -1, -1).ToList();




                return View("SizeView", allpro);
            }
            else
            {
                return View("~/Views/LoginPage/LoginPageView.cshtml");
            }
            }



        [HttpPost]
        public ActionResult SizeView(string mainID, string subID)
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
                var p2 = content.getProSize(userid, -1, categoryid, -1).ToList();
                return View("SizeView", p2);
            }
            else if (subID == "0" && mainID == "0")
            {
                //int categoryid = Convert.ToInt32(subID);
                var p3 = content.getProSize(userid, -1, -1, -1).ToList();
                return View("SizeView", p3);
            }
            else
            {
                int categoryid = Convert.ToInt32(subID);
                var p4 = content.getProSize(userid, categoryid, -1, -1).ToList();
                return View("SizeView", p4);
            }

        }

        [HttpPost]
        public ActionResult SizeByProID(string productID)
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

                var p5 = content.getProSize(userid, -1, -1, -1).ToList();
                return View("SizeView", p5);
            }
            else
            {
                int pid = Convert.ToInt32(productID);

                var p4 = content.getProSize(userid, -1, -1, pid).ToList();
                return View("SizeView", p4);
            }
        }



        ModelService1 ms = new ModelService1();

        [HttpGet]
        public JsonResult UpdateSize(int id, string Sizes)
        {
            bool result = false;
            try
            {
                result = ms.Updatesizes(id, Sizes);
            }
            catch
            {
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

    }

    public class ModelService1 : IDisposable
    {
		private readonly CMSEntities8 content = new CMSEntities8();

		Size s = new Size();
        public bool Updatesizes(int id, string Sizes)
        {


            int a = id;
            string input = Sizes;
            string[] newsizes = Sizes.Split('/');
            int lenght = newsizes.Length;
            var product = content.Products.Where(x => x.productID == a).FirstOrDefault();

            var count = 0;
            foreach (var x in newsizes)
            {
                if (s.IsSizeValid(x))
                {
                    count++;

                }
                else
                {
                    count--;

                }
            }
            if (count == lenght)
            {
                product.Sizes = input;
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
    public class Size
    {
        public bool IsSizeValid(string size)
        {
            string input = size;
            string[] sizelist = { "XXL", "XL", "L", "M", "S", "XS", "XXS", "xxs", "xs", "s", "m", "l", "xl", "xxl" };
            int count = 0;
            foreach (string x in sizelist)
            {
                if (input.Equals(x) && !String.IsNullOrEmpty(input))
                {
                    count++;
                }
                else { }
            }
            if (count >= 1)
                return true;
            else
                return false;

        }
    }
}


