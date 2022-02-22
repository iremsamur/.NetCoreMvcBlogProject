using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            var userMail = User.Identity.Name;//sisteme login olan kullanıcının name değerini tutsun.
          
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();//bu yöntem solidi eziyor.

            var values = writerManager.GetWriterByID(writerID);
            return View(values);
        }


    }
}
