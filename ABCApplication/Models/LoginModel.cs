using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABCApplication.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please input username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please input password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}