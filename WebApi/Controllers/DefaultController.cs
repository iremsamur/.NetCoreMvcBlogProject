using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataAccessLayer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]//Bu rotasyon eğer biz bir api'yi bir web projesi üzerinde
    //UI katmanında çağırmak istersek bu rotasyonu kullanıyoruz.
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //listeleme işlemi
        [HttpGet]//metodun üstüne türünün ne olduğunu belirtiyorum
        //bu bir ekleme mi, silme mi ne ise yazıyorum.
        //listeleme için HttpGet verdim.
        public IActionResult EmpployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();//employee listini bana getiriyor.
            //bu mvc controller'u yani UI içinde yer alan controller olmadığı için view döndürmez.
            return Ok(values);//başarılı olan isteklerin sonucunda dönecek olan Ok status kodu döner.

        }
        [HttpPost]//ekleme işlemi için HttpPost attribute'u actionresult üzerinde kullanılır.
        public IActionResult AddEmployee(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);//yeni bir employee ekle
            c.SaveChanges();//değişiklikleri veritabanına kaydet.
            return Ok();
        }
        //id değerine göre listeleme
        [HttpGet("{id}")]//bir parametre alsın ve bu parametreye göre listeleme yapması için
        //parantez içinde parametre vererek get'i kullanırız.
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);//id'den gelen çalışanı bul
            if (employee == null)
            {
                //listemde olmayan bir id varsa 
                return NotFound();//bana hiçbir şey bulunamadı döndürsün. Yani işlem başarısız
            }
            else
            {
                //eğer o id'ye ait bir çalışan varsa Ok döndürsün. Yani işlem başarılı
                return Ok(employee);
            }
        }
        //veri silme
        [HttpDelete("{id}")]//veri silme işleminde HttpDelete kullanılır.
        //id'ye göre yani bir parametreye göre silmesi için parametre alır.
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);//id'den gelen silinecek çalışanı bul
            if (employee == null)
            {
                //listemde olmayan bir id varsa 
                return NotFound();//bana hiçbir şey bulunamadı döndürsün. Yani işlem başarısız
            }
            else
            {
                //eğer o id'ye ait bir çalışan varsa Ok döndürsün. Yani işlem başarılı
                c.Remove(employee);// o çalışanı sil
                c.SaveChanges();
                return Ok(employee);
            }
        }
        //veri güncelleme
        [HttpPut]//veri güncellemede HttpPut attribute'unu kullanırız
        public IActionResult EmployeeUpdate(Employee employee)//dışarıdan bir employee parametresi alıyor
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.ID);//id'den gelen silinecek çalışanı bul
            if (emp == null)
            {
                //listemde olmayan bir çalışan varsa 
                return NotFound();//bana hiçbir şey bulunamadı döndürsün. Yani işlem başarısız
            }
            else
            {
                //eğer o id'ye ait bir çalışan varsa Ok döndürsün. Yani işlem başarılı
                emp.Name = employee.Name;//değeri güncellesin yani yeni değerini ata
                c.Update(emp);//güncelle
                c.SaveChanges();//değişiklikleri kaydet
                return Ok(employee);
            }
        }


    }
}
