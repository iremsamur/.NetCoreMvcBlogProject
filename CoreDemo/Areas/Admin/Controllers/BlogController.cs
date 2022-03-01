using BusinessLayer.Concrete;
using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        
        public IActionResult ExportStaticExcelBlogList()
        {
            
           
            using (var workbook = new XLWorkbook())//XLWorkbook komutunu kullanıyorum. Excel'de bir workbook olduğu için bu ismi alıyor.
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");//Excel açıldığında altta sayfa 1 yazan yere gelecek olan
                                                                        //ismi verdim.
                                                                        //şimdi hücrelerde ne yazacağını ayarlayalım

                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;//başlangıç değeri . 1.satıra zaten başlık geleceği ve
                //verilerin 2.satırdan itibaren gelebilmesi için BlogrowCount başlangıç değerine 2 verdim.
                foreach(var item in GetBlogList())//şuanda statik olarak verileri getiriyorum. GetBlogList adında bir geçici metod
                    //tanımladım
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;//tanımladığım başlangıç değeri satırından başla 1.sütununa yaz dedik.
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;//Sonraki satıra geçebilmek için her defasında blogrowcount değerini bir arttır.


                }
                //şimdi buradan alacağı verileri excel'e aktaracağı kodları yazalım.
                //IO kütüphanesini kullanıyoruz.

                using(var stream =new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();//içeriği array formatında al
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Calisma1.xlsx");
                    //content'i al ve ikinci parametre de excel'in formatını yazıyoruz. Ve üçüncü parametre olarakda
                    //dosyanın adı xlsx uzantısı ile verilir.
                }



            }
                
        }
        //şuanda verileri statik olarak bir liste içinde tutup GetBlogList metodu ile getirebilmesi için bir metod oluşturuyorum
        List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModel = new List<BlogModel>
            {
                //Şuanda veritabanından veri almadığım için geçici verilerin tutulacağı listeyi döndüren metod yazdım
                new BlogModel{ID=1,BlogName="C# Programlama"},
                 new BlogModel{ID=2,BlogName="Java Programlama"},
                  new BlogModel{ID=3,BlogName="Tesla Araçları"}

            };
            return blogModel;
        }
        //şimdi GetBlogList metodundan gelen verileri excel listeleyecek metodu yazalım
        [AllowAnonymous]
        public IActionResult BlogListExcel()
        {
            //bu metodun bir view'i olacak.
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())//XLWorkbook komutunu kullanıyorum. Excel'de bir workbook olduğu için bu ismi alıyor.
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");//Excel açıldığında altta sayfa 1 yazan yere gelecek olan
                                                                        //ismi verdim.
                                                                        //şimdi hücrelerde ne yazacağını ayarlayalım

                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;//başlangıç değeri . 1.satıra zaten başlık geleceği ve
                //verilerin 2.satırdan itibaren gelebilmesi için BlogrowCount başlangıç değerine 2 verdim.
                foreach (var item in BlogTitleList())//şuanda statik olarak verileri getiriyorum. GetBlogList adında bir geçici metod
                                                   //tanımladım
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;//tanımladığım başlangıç değeri satırından başla 1.sütununa yaz dedik.
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;//Sonraki satıra geçebilmek için her defasında blogrowcount değerini bir arttır.


                }
                //şimdi buradan alacağı verileri excel'e aktaracağı kodları yazalım.
                //IO kütüphanesini kullanıyoruz.

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();//içeriği array formatında al
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                    //content'i al ve ikinci parametre de excel'in formatını yazıyoruz. Ve üçüncü parametre olarakda
                    //dosyanın adı xlsx uzantısı ile verilir.
                }



            }
           

        }
        //veritabanından dinamik olarak çekilen blogverilerin listeleneceği metod
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            //Bu kez bu blog modele context üzerindne değerler gelecek
            using(var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2
                {
                    ID = x.BlogID, //sol taraftaki geçici modeldeki değer iken sağdaki verritabanından gelecek değerdir. 
                    //Veritabanından istediğim verileri select ile alıyorum. Ve BlogModel2'ye atıyorum.
                    BlogName = x.BlogTitle

                }).ToList();
            }
            return bm;
        }
        //şimdi BlogTitleList metodundan gelen veritabanı verilerini excele listeleyecek metodu yazalım
        [AllowAnonymous]
        public IActionResult BlogTitleListExcel()
        {
            //bu metodun bir view'i olacak.
            return View();
        }

    }
}
