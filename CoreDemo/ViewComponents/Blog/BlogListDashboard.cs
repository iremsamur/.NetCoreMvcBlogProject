using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
       
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            //Blogları kategorileriyle birlikte dashboaardda bize listeler
            var values = blogManager.GetBlogListWithCategory();
            return View(values); 
        }
    }
}
