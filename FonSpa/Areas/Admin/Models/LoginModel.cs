using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FonNature.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập UserName !")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập PassWord !")]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}