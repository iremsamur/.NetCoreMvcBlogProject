using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;//önce Identity'den gelen UserManager sınıfından

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //bir constructor tanımlamam gerekiyor.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel user)//içinde
            //task kullanacağımız için async olarak tanımlıyoruz.

        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    //AppUser entity yani veritabanına bağlı entity sınıfının içindeki property değerini
                    //SignUp modelinden türeyen user parametresindeki değere atıyor. Burada
                    //SignUp modeli html tarafında kullanıcının girdiği değerleri tutuyor
                    //Böylece veritabanına aktarım olabiliyor
                    Email = user.Mail,
                    UserName = user.UserName,
                    NameSurname = user.NameSurname


                };
                //şifre identity kütüphanesinde metod çağırılırken gelir
                var result = await _userManager.CreateAsync(appUser, user.Password);//şifreyi kaydedecek.
                //Birisi veritabanı entitysini temsil eden appUser diğer parametre ise
                //html tarafında kullanıcının yazdığı kaydedilecek şifreyi tutan SignUp modelinden gelen değer
                //bunun içim createasync metodu kullanılıyor.
                if (result.Succeeded)
                {
                    //eğer kayıt başarılı olursa Login içinde Index'e atar
                    return RedirectToAction("Index", "Login");
                }
                else

                {
                    //kayıt başarısız olursa errorları döner
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(user);
        }

    }
}
