using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using System.ComponentModel.DataAnnotations;

namespace CMS.Controllers
{
    public class AddProModel
	{
		[Required]
		public string productName { get; set; }
		[Required]
		public string manufactName { get; set; }
		[Required]
		public string size { get; set; }
		[Required]
		public string color { get; set; }
		[Required]
		public int categoryID { get; set; }
		[Required]
		public decimal price { get; set; }
		[Required]
		public int inStock { get; set; }
	}
    public class AddProController : Controller
    {
		private readonly CMSEntities8 content = new CMSEntities8();
		// GET: AddPro
		public ActionResult AddPro()
        {
			if (Session["userid"] != null)
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

                return View();
			}
			else
			{
				return View("~/Views/LoginPage/LoginPageView.cshtml");
			}
            
        }
       
        [HttpPost]
        public ActionResult AddPro(AddProModel p, string mainID,  string subID)
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


            int userid = ((int)Session["userid"]);
            string productname = p.productName;
            string manu = p.manufactName;
            string size = p.size;
            string color = p.color;
            int category = Convert.ToInt32(subID);
            if (category > 2 && category < 17)
            {
                decimal price = Convert.ToDecimal(p.price);
                int InStock = Convert.ToInt32(p.inStock);



                try
                {
                    content.addProduct(userid, productname, manu, size, color, category, price, InStock);
                    content.SaveChanges();
                    return RedirectToAction("Products", "ProductPage");
                }
                catch
                {
                    return View("AddPro");
                }
            }
            else
                return View("AddPro");
          
           
        }
    }
}