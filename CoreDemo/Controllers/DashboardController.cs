using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            //Toplam blog sayısını bulalım.
            Context c = new Context();
            var username = User.Identity.Name;//sisteme login olan kullanıcının name değerini tutsun.
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //tuttuğu name'e göre o name'e sahip kullanıcının mailini getirsin
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            //aldığı mail adresine göre
            //o mail adresine sahip yazarın ID değerini veriyor.



            ViewBag.value1 = c.Blogs.Count().ToString();//Toplam blog sayısını veriyor.
            ViewBag.value2 = c.Blogs.Where(x => x.WriterID == writerID).Count().ToString();//yazara ait blog sayısını veriyor.
            //burada giriş yapan kullanıcının id'sini alıp id'sine göre onun bilgilerini getirmeli
            //böylece sisteme giriş yapan yazarın verileri gelir
            ViewBag.value3 = c.Categories.Count().ToString();
            return View();
        }
    }
}
