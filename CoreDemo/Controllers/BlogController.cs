using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
   
    public class BlogController : Controller
    {

        //Blogla ilgili verilerin getirileceği alan 
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            //Bu index blogların listelendiği sayfa olacak
            return View(values);
        }
        //Blog detayları sayfasını oluşturmak için, tüm sayfa yani view olur.
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;//bu komut ile tıklanan blogun id değerini tutabilirim.
            
            var values = blogManager.GetBlogByID(id);
            
            return View(values);
        }
        //ben yazarla ilişkili bir action tanımlayacağım
        public IActionResult BlogListByWriter()//yazara göre o yazarın bloglarını getirecek
        {
            var userMail = User.Identity.Name;//sisteme login olan kullanıcının name değerini tutsun.

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            var values = blogManager.GetListWithCategoryByWriterBm(writerID);//giriş yapan kullanıcının id'sini alıyor
            //Ve o id'ye göre blogları listeliyor.
            return View(values);
        }
        //Blog ekleme işlemini yazalım
        //sisteme kayıt olmuş yazar ekleme işlemi yapar
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            //kategorileri dropdown list içinde listelemek için
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                       /*Dropdown'un text ve value olarak iki parametresi vardır. Text kullanıcıya görünen kısım value ise 
                                                        bunun id değeri olur.*/
                                                   }).ToList() ;
            ViewBag.cv = categoryValues;//categoryvalues'dan gelen değerleri tutar
                                                
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            //Yazığım Validasyonları kontrol etmek için WriterValidator sınıfını çağırıyorum.
            BlogValidator blogValidator = new BlogValidator();
            //ValidatonResult isminde bir sınıfım var bunun metodlarını kullanabilmek için bunu da çağırıyorum.
            ValidationResult results = blogValidator.Validate(blog); //Writer sınıfı için tüm bu WriterValidator içindeki kontrolleri yap
            var userMail = User.Identity.Name;//sisteme login olan kullanıcının name değerini tutsun.

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            if (results.IsValid)//Eğer sonuçlar geçerli ise
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;
               
                

                blogManager.TAdd(blog);
               
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                
                


                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();//işlem geçersiz ise bana bir view döndürür.
            
        }
        //blog silme işlemini yazalım
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = blogManager.TGetById(id);
            blogManager.TDelete(blogValue);//Bu bize bu id'deki bloglara karşılık gelen satırın tamamını bulur. Ve siler.
            return RedirectToAction("BlogListByWriter");

        }
        //blog düzenleme işlemi
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            
            var blogValue = blogManager.TGetById(id);
            
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                       /*Dropdown'un text ve value olarak iki parametresi vardır. Text kullanıcıya görünen kısım value ise 
                                                        bunun id değeri olur.*/
                                                   }).ToList();
            ViewBag.cv = categoryValues;//categoryvalues'dan gelen değerleri tutar
            return View(blogValue);//bulmuş olduğun id'nin blog değerlerini döndürür. View sayfasına taşıyacak.
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            /*
            var blogIDValue = blogManager.TGetById(blog.BlogID);
            blogIDValue.BlogTitle = blog.BlogTitle;
           
           
            blogIDValue.BlogImage = blog.BlogImage;
            blogIDValue.BlogContent = blog.BlogContent;
            blogIDValue.BlogThumbnailImage = blog.BlogThumbnailImage;
            blogIDValue.CategoryID = blog.CategoryID;
            */
            var oldBlogValues = blogManager.TGetById(blog.BlogID);//blogun güncellenmeden önceki bilgilerini getiriyorum.
            blog.BlogStatus = oldBlogValues.BlogStatus;//değişmesini istemediklerimi bununla yeni haline aktarıyorum. Eski bilgilerini
            //yeni haline aktarır.
            blog.WriterID = oldBlogValues.WriterID;
            blog.BlogCreateDate = oldBlogValues.BlogCreateDate;
         
            
          


            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }


    }
}
