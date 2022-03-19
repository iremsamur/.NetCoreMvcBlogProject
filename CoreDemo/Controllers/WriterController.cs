using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
   
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;//sistemde o anda giriş yapmış aktif kullanıcının name bilgisini tutar.
            ViewBag.m = userMail;//bu name değerini frontend tarafına viewbag ile taşıyalım.
            //giriş yapan yazarın name değeri dışındaki diğer bilgilerini aşağıdaki metod uygun olmasa bile bu yöntemle 
            //getirebiliriz.
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y=>y.WriterName).FirstOrDefault();
            ViewBag.m2 = writerName;
            
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        //yazar navbar için bir partialview oluşturuyorum.
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        //Writer footer alanı için partialview
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();

        }
       
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            //var username = User.Identity.Name;//sisteme login olan kullanıcının name değerini tutsun.
            //sonra username'den usermail'i çekmeliyim
            //var username = User.Identity.Name;

            //var userMail = c.Users.Where(x => x.UserName== username).Select(y => y.Email).FirstOrDefault();//usermaili getirerek
            //UserManager userManager = new UserManager(new EfUserRepository());

            //var id = c.Users.Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();//maile göre id'li kullanıcıyı getirir.
            //var values = userManager.TGetById(id);
            var values = await _userManager.FindByNameAsync(User.Identity.Name);//sisteme giriş yaptığım kullanıcı adı yani name'i veriyorum
            UserUpdateViewModel model= new UserUpdateViewModel();
            //frontend tarafında verileri listelemek için
            //frontendde verileri tutan modele veritabanından gelen verileri atıyor.
            model.mailadress = values.Email;
            model.namesurname = values.NameSurname;//frontend tarafında verileri listelemek için
            //frontendde verileri tutan modele veritabanından gelen verileri atıyor.
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;

            return View(model);

        }
        
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            values.Email = model.mailadress;//burada ise benim gönderdiğim modelin maili yani
                                            //kullanıcının textboxdan girdiği yeni değeri
                                            //veritabanındaki değerine eşitleyerek güncelliyor.
            
            values.NameSurname = model.namesurname;
            
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.password);
            //şifre güncelleme için HasPassword metodunu kullanırım.
            //bu parametre olarak veritabanından identity ile giriş yapan kullanıcının bilgilerini çekerken
            //aldığım values'u gönderiyorum. Ve 2.parametre içinde modeldeki yeni şifre değerini gönderiyorum
            var result = await _userManager.UpdateAsync(values);//Update async ile değerleri güncelle
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");

            }
            return RedirectToAction("WriterEditProfile", "Writer");








            ////yazarın bilgilerini güncelleme işlemini yapacağı alan
            ////Güncelleme işlemi için önce Validator'ı çağırırız. Çünkü validasyondan geçmesi gerekir.
            //UserValidator userValidator = new UserValidator();
            //ValidationResult results = userValidator.Validate(p);
            //UserManager userManager = new UserManager(new EfUserRepository());


            //if (results.IsValid && p.PasswordHash.Equals(p.PasswordAgain))//Eğer sonuçlar geçerli ise
            //{
            //    //eğer validasyon true olursa, sorun yoksa validasyona uygunsa güncellesin

            //    userManager.TUpdate(p);//gelen değeri güncellesin.
            //    return RedirectToAction("Index", "Dashboard");//Beni Dashboard içinde yer alan index aksiyonuna yönlendirsin.
            //}
            //else
            //{
            //    //Eğer geçerli değilse
            //    if (p.PasswordAgain != null)//hata almamak için eğer null değerinden farklıysa bu kontrolü yapmalı
            //    {
            //        if (p.PasswordHash.Equals(p.PasswordAgain) == false)
            //        {
            //            ModelState.AddModelError("WriterPasswordAgain", "Şifre tekrar alanı girdiğiniz şifre ile uyumlu olmalıdır!!");
            //            //password ve confirm password için uyumsuzluk durumunda  hata mesajı verebilmesi için bir AddModelError ekledim.
            //        }
            //    }


            //    //validasyonu sağlamaz. Hata olursa
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }
        //yeni yazar ekleme alanı
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writerModel)
        {
            //Yazarın seçtiği dosyayı yüklemesi işlemi
            Writer writer = new Writer();
            if (writerModel.WriterImage != null)
            {
                //writerImage değeri null değilse resimleri içine koyacağımız WriterImageFiles klasörü içine kopyalama yapılacak
                var extension = Path.GetExtension(writerModel.WriterImage.FileName);//gelen resmin kopyasını alır. Yüklenen resmin
                var newImageName = Guid.NewGuid() + extension;//Yüklenen resmin yeni ismi
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);//Belirtilen klasör
                 //konumuna yani klasör içine 
                //yüklenen resmi atar. Yani resmin kopyalanacağı klasör konumunu veriyoruz.
                var stream = new FileStream(location, FileMode.Create);//Dosya oluştur.
                writerModel.WriterImage.CopyTo(stream);//Yüklenen dosyayı Dosya akışına kopyala.
                writer.WriterImage = newImageName;//Writer sınıfındaki yani veritabanındaki writerImage değeri newImageName'den gelen değer olsun.
              


            }
            /*
               Html tarafında kullanıcının gireceği verileri AddProfileImage model sınıfını kullanarak alacağım için
              bu verileri asıl veritabanı bilgilerini tutan entity sınıfının değerlerine atamam gerekiyor. Çünkü veritabanınada ekleyebilmesi lazım
              aşağıdaki işlemi o yüzden yapıyorum.*/
            writer.WriterMail = writerModel.WriterMail;
            writer.WriterName = writerModel.WriterName;
            writer.WriterPassword = writerModel.WriterPassword;
            writer.WriterPasswordAgain = writerModel.WriterPasswordAgain;
            writer.WriterStatus = true;
            writer.WriterAbout = writerModel.WriterAbout;

            writerManager.TAdd(writer);//ekleyeceğim kısımı veritabanıyla bağlantılı olan
            //Writer entitysi olduğu için Writer'dan türeyen writer nesnesini veriyorum. 
            //çünkü AddProfileImage asıl entity'nin kopyasıydı o veritabanına bağlı değildi.

            return RedirectToAction("Index", "Dashboard");
        }
       
    }
}
