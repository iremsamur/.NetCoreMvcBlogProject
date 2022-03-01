using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = blogManager.GetList().Count();//Viewbag ile toplam blog sayısını alıp html'e taşır.
            ViewBag.v2 = context.Contacts.Count();// toplam admine gelen mesaj sayısı
            ViewBag.v3 = context.Comments.Count();//toplam yorum sayısı
            return View();
        }
    }
}
