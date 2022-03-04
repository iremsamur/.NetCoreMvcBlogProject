using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        //Bu Index action'u kategorilerin frontend üzerinde yani grafik üzerinde listeleneceği action olacak
        
        public IActionResult Index()
        {
            return View();
        }
        //Burası chartın oluşturulacağı kategoriler için şuanda 
        //verilerin veritabanı olmadan dinamik olarak eklenip listeleneceği yer olacak.

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryName = "Teknoloji",
                categoryCount = 10
            });
            list.Add(new CategoryClass
            {
                categoryName = "Yazılım",
                categoryCount = 14
            });
            list.Add(new CategoryClass
            {
                categoryName = "Spor",
                categoryCount = 5
            });
            return Json(new { jsonlist = list });//verileri listte tutulan kategori verilerini google chart'a göndermek için
            //json olarak döndürüyorum.
            //bu jsonlist json'uma verdiğim ismi script tarafında kullanacağız
        }
    }
}
