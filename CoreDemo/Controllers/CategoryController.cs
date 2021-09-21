using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        //şimdi CategoryManager'ı UI katmanında çağırarak kullanabilirim. Kategori işlemlerini gerçekleştirmek için
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        //Böylece CategoryManager sınıfını çağırarak içine Data Access layer içindeki EfCategoryRepository sınıfını vererek çağırdım.
        //Bu categoryManager nesnesi ile bütün metodlara erişim sağlayabilirim.
        public IActionResult Index()
        {
            //kategorileri listeleyecek
            //Normal da .net framework de Action Result olarak gelen kısımlar burada IAction Result olarak geliyor.
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
