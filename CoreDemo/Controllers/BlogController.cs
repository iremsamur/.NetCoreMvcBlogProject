using BusinessLayer.Concrete;
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
    public class BlogController : Controller
    {
        //Blogla ilgili verilerin getirileceği alan 
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            //Bu index blogların listelendiği sayfa olacak
            return View(values);
        }
        //Blog detayları sayfasını oluşturmak için, tüm sayfa yani view olur.
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;//bu komut ile tıklanan blogun id değerini tutabilirim.
            
            var values = blogManager.GetBlogByID(id);
            
            return View(values);
        }
        
    }
}
