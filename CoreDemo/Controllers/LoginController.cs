using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer writer) //Bunun view'i Login sayfasına gider.
        {
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

            
        }
    }
}
