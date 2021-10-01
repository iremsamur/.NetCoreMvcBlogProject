using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        //Yorumlar bölümünü düzenlemek için bir partial view yazalım.
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        //Yorumları listeleyelim. Yani o bloga ait yorumları listeleyecek
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = commentManager.GetList(id);
            ViewBag.a = values.Count;
            
            return PartialView(values);
        }
    }
}
