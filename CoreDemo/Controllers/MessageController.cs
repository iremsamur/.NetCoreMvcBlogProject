using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult InBox()//Gönderilen Mesajlar
        {
            
            var username = User.Identity.Name;//sisteme login olan kullanıcının name değerini tutsun.
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //giriş yapan kullanıcının name'ini username ile tutuyorum. Ve bu username değerine sahip olan kullanıcının
            //mailini çeker. Böylece userMail'i aldım. Böylece sisteme otantike olan kullanıcının mailini alabiliyorum


            var writerID = c.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
            var values = messageManager.GetInBoxListByWriter(writerID);
            return View(values);
        }

        //Mesaj detayları alanı
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {

            var value = messageManager.TGetById(id);

            
            return View(value);
        }
    }
}
