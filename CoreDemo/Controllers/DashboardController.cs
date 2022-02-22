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


            ViewBag.value1 = c.Blogs.Count().ToString();//Toplam blog sayısını veriyor.
            ViewBag.value2 = c.Blogs.Where(x => x.WriterID == 1).Count().ToString();//yazara ait blog sayısını veriyor.
            ViewBag.value3 = c.Categories.Count().ToString();
            return View();
        }
    }
}
