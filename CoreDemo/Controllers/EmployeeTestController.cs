using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()//apiye erişeceğimiz için
                                                //buradaki metodu asenkronik async tanımlıyoruz. Sen asenkronik olarak çalışacaksın
                                                //çünkü apilerle çalışıyoruz
        {
            var httpClient = new HttpClient();//httpclient'ı çağırıyorum
            var responseMessage = await httpClient.GetAsync("https://localhost:44358/api/Default");
            //verileri listelemek için httpclient'dan getasync kullanılır.
            //istek göndereceğim web api adresini yazacağım. Bu url'i web apideki ilgili request url'dan aldım.
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);//burada deserializeobject kullanıyoruz.
            //Bazılarında serialize bazılarında deserialize olur. Buraya Benmi employee'daki propertylerimi
            //karşılamak için verileri tutacağım geçici bir Class1 sınıfını veriyorum.

            return View(values);
        }
       //şimdi ekleme işlemi yazalım.
       [HttpGet]
       public IActionResult AddEmployee()
        {
            return View();
        }
        //ek işlemi backend operasyonlarının yazılacağı apinin çağırılacağı metod
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {

            var httpClient = new HttpClient();//httpclient'ı çağırıyorum
            //listeleme işleminde Deserialize kullanılırken eklemede serialize kullanılır
            var jsonEmployee = JsonConvert.SerializeObject(p);//ekleyeceğim parametreyi serialize eder.
            StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");//1.parametre contentin içertiği
            //2. türü encoding türü, 3.türü mediatype
            //türkçe karakter için UTF8 verdim. Ve apiden gelen veriler olduğu için türe json verdim
            var responseMessage = await httpClient.PostAsync("https://localhost:44358/api/Default", content);
            //ekleme işlemi içinde PostAsync kullanılır.
            //Yani web api tarafı kodlarıın c#'a göre webde backendde yazıyorum
            if (responseMessage.IsSuccessStatusCode)
            {
                //eğer başarılı ise
                return RedirectToAction("Index");
            }
            return View(p);
        }
        //düzenleme işlemi
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            //bana güncellenecek kullanıcı verilerini getirir.
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44358/api/Default/" + id);//id değerine göre veriyi alıyor
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);


            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        //güncelleme işlemi
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44358/api/Default/",content);
            //responseMessage'da apiye bağlı gerçekleşecek işlemi yazıyoruz.
            //güncelleme işleminde putasync kullanılır
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");//güncelleme olursa Index'e yönlendir.
            }
            return View(p);//güncelleme işlemi gerçekleşmezse parametreyi döndürüyor.
        }
        //silme işlemi
       
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            //bana silinecek kullanıcı verilerini getirir.
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44358/api/Default/" + id);//id değerine göre veriyi alıyor
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");


            }
            return View();
           
        }

    }
    public class Class1{
        //Employee property'lerini değerlerini karşılayacak geçici sınıf
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
