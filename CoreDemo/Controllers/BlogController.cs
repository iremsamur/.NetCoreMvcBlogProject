using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        //Blogla ilgili verilerin getirileceği alan 
        public IActionResult Index()
        {
            //Bu index blogların listelendiği sayfa olacak
            return View();
        }
    }
}
