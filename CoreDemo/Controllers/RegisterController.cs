using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            //Yazığım Validasyonları kontrol etmek için WriterValidator sınıfını çağırıyorum.
            WriterValidator writerValidator = new WriterValidator();
            //ValidatonResult isminde bir sınıfım var bunun metodlarını kullanabilmek için bunu da çağırıyorum.
            ValidationResult results = writerValidator.Validate(writer); //Writer sınıfı için tüm bu WriterValidator içindeki kontrolleri yap
            if (results.IsValid)//Eğer sonuçlar geçerli ise
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";//Writerstatus ve about değerlerini buradan gönderiyoruz.
                                                   //Şimdi ekleme işlemini yapalım.
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                //Eğer geçerli değilse
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();//işlem geçersiz ise bana bir view döndürür.
            
        }
    }
}
