using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        //bu sınıfın bir ViewComponent olduğunu belirtmek için ASPNetCore'daki Mvc ViewComponent'dan miras alması gerekir.
        //şimdi burada controller'daki gibi Invoke adında bir  result metodu tanımlarım. ama bu IViewComponentResult olur.
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    Username="İrem"
                },
                new UserComment
                {
                    ID=2,
                    Username="Murat"
                },
                 new UserComment
                {
                    ID=3,
                    Username="Merve"
                }
            };
            return View(commentValues);
        }

    }
}
