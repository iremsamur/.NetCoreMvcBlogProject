using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{


    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;//Identity Register işlemi için
        //nasıl UserManager kullandıysam login işlemi için ise
        //SignInManager sınıfı kullanılır. Ve yine AppUser için çalışır.

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index() //Bunun view'i Login sayfasına gider.
        {
            return View();
        }
        [HttpPost]
        //Identity ile login işlemi
        public async Task<IActionResult> Index(UserSignInViewModel p )
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                //ilk parametrelere login için hangi değerleri girmesi gerekiyor username ve password ile login yapacak dedik.
                //üçüncü parametre tarayıcı çerezlerde (cookie) hatırlasın mı true ya da false veriyoruz.
                //ve 4.parametre lockoutOnFailure değeri. AspNetUsers tablosunda bulunan accessfailedaccount için true olursa
                //kişinin sisteme otantike olurken yanlış girme durumlarının sayısı yain 5 defa yanlış giriş yaparsa belli bir süre
                //banlanıcak. Sisteme girişi engellenecek
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
                

            }
            return View();




        }
        //kullanıcının çıkış yapmasını sağlama
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");

        }


        
    }
}
