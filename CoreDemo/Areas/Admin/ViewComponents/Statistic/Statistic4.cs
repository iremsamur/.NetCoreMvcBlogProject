using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            //şimdilik session olmadan yazıyorum. ID'si 1 olan adminin name değerini select ile çek dedim
            ViewBag.v2 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();//admin resmi
            ViewBag.v3 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();//admin kısa açıklama

            return View();
        }

    }
}
