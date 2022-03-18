using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context c = new Context();//Bu context yöntemiyle sisteme login olan kullanıcının bilgilerini getirirsem
                                  //başka session'dan çağırdığım için solidi ezmiş oluyorum.

       

        public IViewComponentResult Invoke()
        {
            

            var username = User.Identity.Name;//sisteme login olan kullanıcının name değerini tutsun.
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //giriş yapan kullanıcının name'ini username ile tutuyorum. Ve bu username değerine sahip olan kullanıcının
            //mailini çeker. Böylece userMail'i aldım. Böylece sisteme otantike olan kullanıcının mailini alabiliyorum
           
          
            var writerID = c.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();//bu yöntem solidi eziyor.

            var values = writerManager.GetWriterByID(writerID);
            return View(values);
        }


    }
}
