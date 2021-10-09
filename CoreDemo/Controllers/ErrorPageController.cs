using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class ErrorPageController : Controller
    {
        //404 hata kontrolü için bu Error1 bir code parametresi alır.
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
