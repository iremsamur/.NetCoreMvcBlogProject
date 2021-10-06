using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models.AdditionalModels;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            if (results.IsValid && writer.WriterPassword.Equals(writer.WriterPasswordAgain))//Eğer sonuçlar geçerli ise
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
                if(writer.WriterPasswordAgain != null)//hata almamak için eğer null değerinden farklıysa bu kontrolü yapmalı
                {
                    if (writer.WriterPassword.Equals(writer.WriterPasswordAgain) == false)
                    {
                        ModelState.AddModelError("WriterPasswordAgain", "Şifre tekrar alanı girdiğiniz şifre ile uyumlu olmalıdır!!");
                        //password ve confirm password için uyumsuzluk durumunda  hata mesajı verebilmesi için bir AddModelError ekledim.
                    }
                }
               
                
                foreach (var item in results.Errors)
                {
                    
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
          
            
            return View();//işlem geçersiz ise bana bir view döndürür.
            
        }
        /*
        public List<SelectListItem> GetCityList()
        {
            List<SelectListItem> citySelection = (from x in GetCity()
                                              select new SelectListItem
                                              {
                                                  Text = x,
                                                  Value = x
                                              }).ToList();
            return citySelection;
        }
        public List<string> GetCity()
        {
            String[] CitiesArray = new String[] { "Adana", "Adıyaman", "Afyon", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Bartın", "Batman", "Balıkesir", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İçel", "İstanbul", "İzmir", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Şırnak", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
            return new List<string>(CitiesArray);
        }
        */
    }
}
