using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.ViewModel
{
	public class Uservm
	{
		public int userID { get; set; }
		public string userName { get; set; }
		[Required(ErrorMessage = "Login Number is required")]
		public Nullable<int> LoginID { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string LoginPwd { get; set; }
		public string UserRole { get; set; }
		public string contact { get; set; }
		public string UserAddress { get; set; }
		[Required(ErrorMessage = "Your passcode is required")]
		[System.ComponentModel.DataAnnotations.Compare("LoginPwd", ErrorMessage = "The new password and confirmation password do not match")]
		public string LoginPwd2 { get; set; }
		public bool rememberMe { get; set; }
	}

	public class Ordersvm
	{
		public int orderID { get; set; }
		public string customerName { get; set; }
		public Nullable<System.DateTime> OrderDate { get; set; }
		public Nullable<int> customerID { get; set; }
		public Nullable<System.DateTime> RequiredDate { get; set; }
		public string ShippingStatus { get; set; }
		public Nullable<int> shipperID { get; set; }
		public string ShippingAddress { get; set; }
		public string BillingAddress { get; set; }
	}
	public class SalesReportvm
	{
		public int productID { get; set; }
		public Nullable<int> NumberSold { get; set; }
		public Nullable<int> NumberLeftInStock { get; set; }
	}
	public class SalesInventoryvm
	{
		public int productID { get; set; }
		public Nullable<int> userID { get; set; }
		public string productName { get; set; }
		public string manufacturerName { get; set; }
		public string Sizes { get; set; }
		public string Colors { get; set; }
		public Nullable<int> categoryID { get; set; }
		public Nullable<decimal> UnitPrice { get; set; }
		public Nullable<int> unitsInStock { get; set; }
		public Nullable<int> Qty_in_Stock { get; set; }
	}
}