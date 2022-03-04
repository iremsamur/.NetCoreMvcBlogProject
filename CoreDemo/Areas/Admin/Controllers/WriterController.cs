using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);//gelen list türündeki writerclass değerini serializeobject ile
            //json türüne dönüştürecek.

            return Json(jsonWriters);//ve bu json türündeki nesneyi döndürüyor.
        }
        //yine verileri static olarak listeleteceğim
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                name="Ayşe"
            },
             new WriterClass
            {
                Id=2,
                name="Ahmet"
            },
              new WriterClass
            {
                Id=3,
                name="Zeynep"
            }

        };
    }
}
