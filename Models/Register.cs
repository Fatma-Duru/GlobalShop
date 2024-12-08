using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalShop.Models
{
    public class Register
    {

        [Required(ErrorMessage = "Adınız alanı zorunludur.")]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadınız alanı zorunludur.")]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı zorunludur.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [DisplayName("E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı zorunludur.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [DisplayName("Şifre Tekrar")]
        public string RePassword { get; set; }
    }

}