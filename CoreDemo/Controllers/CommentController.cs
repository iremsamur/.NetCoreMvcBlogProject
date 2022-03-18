using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        //Yorumlar bölümünü düzenlemek için bir partial view yazalım.
        //yorum bırakma alanı için
        //Bu maildeki sorunu çözmek için IActionResultkullanırız.
        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());//yorumun bırakılma tarihini bu çalıştırıldığı anın tarihini verdim.
            comment.CommentStatus = true;//yorumun yayınlanma durumunu true yaptım.
            //Burada yorum ekleye tıklandığında önceden her yorum için otomatik verilecek değerleri verdim. CommentDate, CommentStatus gibi.
            comment.BlogID = 4;
            commentManager.CommentAdd(comment);
            return RedirectToAction("Index", "Blog");
        }
        

        /*
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());//yorumun bırakılma tarihini bu çalıştırıldığı anın tarihini verdim.
            comment.CommentStatus = true;//yorumun yayınlanma durumunu true yaptım.
            //Burada yorum ekleye tıklandığında önceden her yorum için otomatik verilecek değerleri verdim. CommentDate, CommentStatus gibi.
            comment.BlogID = 4;
            commentManager.CommentAdd(comment);
            return PartialView();
        }
        */
        //Yorumları listeleyelim. Yani o bloga ait yorumları listeleyecek
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = commentManager.GetList(id);
            ViewBag.a = values.Count;
            
            return PartialView(values);
        }
    }
}
