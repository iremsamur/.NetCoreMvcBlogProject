using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index() //Bunun view'i Login sayfasına gider.
        {
            return View();
        }
    }
}
