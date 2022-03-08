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
        //Dışarıdan gönderdiğim değere göre o parametredeki değeri getirme
        public IActionResult GetWriterByID(int writerid)
        {
            //gönderilen ID değerine sahip yazarı bulup bana getirecek
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        //AJAX ile ekleme işlemi
        public IActionResult AddWriter(WriterClass writerclass)
        {
            writers.Add(writerclass);//parametre olarak gönderilen değeri ekliyor
            var jsonWriters = JsonConvert.SerializeObject(writerclass);//eklediği değeri json olarak döndürecek
            return Json(jsonWriters);
        }
        //AJAX ile silme işlemi
        public IActionResult DeleteWriter(int writerid)
        {
            var writer = writers.FirstOrDefault(x => x.Id == writerid);// o id ye ait yazarı bul
            writers.Remove(writer);// o yazarı sil
            return Json(writer);//silinen yazarı döndürsün
        }
        //AJAX ile güncelleme işlemi
        public IActionResult UpdateWriter(WriterClass writerClass)
        {
            var writer = writers.FirstOrDefault(x => x.Id == writerClass.Id);//o id'ye ait yazar
            writer.name = writerClass.name;//değerleri güncelliyor.
            var jsonWriter = JsonConvert.SerializeObject(writerClass);
            return Json(jsonWriter);//güncellenen yazarı döndür.
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
