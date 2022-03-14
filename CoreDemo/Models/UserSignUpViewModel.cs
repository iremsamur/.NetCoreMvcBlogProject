using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        //Register işlemini bu model üzerinden gerçekleştireceğim.
        [Display(Name ="Ad Soyad")]//span etiketi için name değeri
        [Required(ErrorMessage="Lütfen ad-soyad bilgisini giriniz.")]//değerin zorunlu olması için annotation
        public string NameSurname { get; set; }
        [Display(Name = "Şifre")]//span etiketi için name değeri
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]//değerin zorunlu olması için annotation
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]//span etiketi için name değeri
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor.")]//Burada Compare kullanıyoruz. Compare eşleştirme yapacak.
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail Adresi")]//span etiketi için name değeri
        [Required(ErrorMessage = "Lütfen mail adresi giriniz.")]//değerin zorunlu olması için annotation
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adı")]//span etiketi için name değeri
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]//değerin zorunlu olması için annotation
        public string UserName { get; set; }

    }
}
