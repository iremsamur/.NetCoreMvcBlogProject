using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            //api'den gelen hava durumunu çekeceğim kodlarımı buradan yazıyorum
            string api = "api key";// openweather'dan hava durumu bilgisi çekebilmek için oluşturduğum api key
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid="+api;
            //bağlantı adresini yazıyoruz
            XDocument document = XDocument.Load(connection);//bana xml dökümanını getirecek
            //şimdi xml'den çekmek istediğim bilgileri çağırıyorum
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;//Descendants metodu içine xml'de çekmek
                                                                                                  //istediğim alanları yazıyorum
            //mesela  <temperature value="1.9" min="1.66" max="2.58" unit="celsius"/> alanından temperature yazarak sıcaklık çekerim
            //veya diğer alanlar için diğer uygun alanların adını veririm.
            //Sonra ElementAt fonksiyonu ile hangi index'te değeri çekmek istiyorsam ona veriyorum
            //Mesela burada 0. indisteki değeri getir dedim.
            //sonra attribute ile bu temperature alanına baktığımda min, max,value farklı değerler alanlar var
            //Attribute içinde hangi alanı istediğimi belirtiyorum. Value mu max mı neyi çekmek istiyorum?
            //sıcaklık için value'yu verdik





            return View();
        }
    }
}
