using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    
   
    public class LoginController : Controller
    {

        
       
        [AllowAnonymous]
        public IActionResult Index() //Bunun view'i Login sayfasına gider.
        {
            return View();
        }
        //sisteme login olma
        //[AllowAnonymous]
        [HttpPost]
        [AllowAnonymous] //Cookie kullanımı ile login yazdığımda artık bunu yazmama gerek yok
        public async Task<IActionResult> Index(Writer writer) //Bunun view'i Login sayfasına gider.
            //burada multitasking bir kullanım yapıyorum. asyn Task ile

        {
            //Farklı yöntemle login işlemini yazma
            Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && 
            x.WriterPassword == writer.WriterPassword);
            if(dataValue != null)
            {
                var claims = new List<Claim>
                {  // Biz burada talep oluşturuyoruz

                    new Claim(ClaimTypes.Name,writer.WriterMail) //Claim sınıfı içinde ClaimTypes.Name metodunu
                    //kullanıyorum. Ve parametre olarak giriş yapmak için gerekli olan e posta değerini
                    //name değerini veririm.

                };
                var userIdentity = new ClaimsIdentity(claims, "a");//benim burada claims ikinci oarametrede
                                                                   //tarafında herhangi bir string değer göndermem gerekiyor.
                                                                   //Eğer bu değeri göndermezsem sisteme authentice olamam
                                                                   //Burada a dedim , istediğim değeri verebilirim.
                                                                   //buda bir üst satırdaki claims değişkenini parametre alır.
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);//bir üst satırdaki userIdentity değişkenini
                //parametre olarak alıyor.
                //gelen değere şifreli formatta cokkie oluşturalım
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
            /*
             * Session yöntemi- Eski yöntem
             * Session yöntemini kullanmayacağım içim bunu yorum satırı yaptım.
            Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            //veritabanından gelen şifre kullanıcının girdiği yani writer parametresinden
            //gelen şifreye eşitse ve aynı şekilde mailde doğruysa anlamındadır.
            //FirstorDefault tek değer üzerinde sorgulama ya da işlem yapmak için kullanılır.
            if(dataValue != null)//bu değer null değilse
            {
                HttpContext.Session.SetString("username", writer.WriterMail);//username'e ve writermail'e göre işlem yap
                return RedirectToAction("Index", "Writer");//sen beni writer index'e yönlendir dedim

            }
            else
            {
                return View();
            }
            */

            
        }
    }
}
