using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
	public class loginModel
	{
		[Required(ErrorMessage = "Login Number is required")]
		public int loginID { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string loginPwd { get; set; }
		public bool rememberMe { get; set; }
	}
}