using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GlobalShop.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Kullanıcı Adı alanı zorunludur.")]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [DisplayName("Şifre")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }

    }
}