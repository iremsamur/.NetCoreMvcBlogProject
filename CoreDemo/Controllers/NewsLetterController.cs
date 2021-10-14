using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            
            newsLetter.MailStatus = true;//ekleme yapmadan önce yeni eklenecek mailin statusunu true yap
            newsLetterManager.AddNewsLetter(newsLetter);
            ViewBag.operationControl = true;//başarılı veya başarısız sweet alerti için işlemin olup olmadığının değerini döndürüyor.
            return RedirectToAction("Index", "Blog");
        }
        /*
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;//ekleme yapmadan önce yeni eklenecek mailin statusunu true yap
            newsLetterManager.AddNewsLetter(newsLetter);
            return PartialView();

        }
        */

        
     
    }
}
