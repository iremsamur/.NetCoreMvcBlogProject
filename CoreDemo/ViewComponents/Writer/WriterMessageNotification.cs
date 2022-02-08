using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "iremsamur129@gmail.com";//burası sessiondan gelecek en son yazar işlemleri bittiğinde session'a bağlanacak
            var values = messageManager.GetInBoxListByWriter(p);
           
            return View(values);
        }

    }
}
