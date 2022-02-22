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
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")] //Burada Controller bazında Area attribute vererek ve () içinde Admin ismini vererek, bu Controller'da yer alan
    //result metodlarının Area'dan gelen metodlar olduğunu ve Adının Admin areasından geldiğini belirtmiş oluyorum.
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)//page'e 1 vererek page 1'den başlasın diyoruz. page sayfa değişkeni
        {
            //Kategorileri listeleyecek
            var values = categoryManager.GetList().ToPagedList(page,3);//sayfalama için ToPagedList metodu kullanılır. Ve içine
            //iki parametre alır. Birinci sayfalama hangi sayfadan başlasın. page verdim, page'den gelen değerden başlasın.
            //İkinci parametrede her bir sayfada kaç değerim olacak, onada 3 verdim.
            return View(values);
        }
        //Kategori ekleme işlemi
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            //Yazığım Validasyonları kontrol etmek için WriterValidator sınıfını çağırıyorum.
            CategoryValidator categoryValidator = new CategoryValidator();
            //ValidatonResult isminde bir sınıfım var bunun metodlarını kullanabilmek için bunu da çağırıyorum.
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.TAdd(category);
                return RedirectToAction("Index", "Category");

            }
            else
            {
                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            

           
            return View();
        }
        //Kategori silme işlemi
        public IActionResult DeleteCategory(int id)//view tarafından seçilen kategorinin id'sini tutuyor. O id'li kategoriyi siler.
        {
            var categoryValue = categoryManager.TGetById(id);
            categoryManager.TDelete(categoryValue);//Bu bize bu id'deki bloglara karşılık gelen satırın tamamını bulur. Ve siler.
            return RedirectToAction("Index");
        }


    }
}
