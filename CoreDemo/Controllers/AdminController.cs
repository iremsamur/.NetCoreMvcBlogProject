using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class AdminController : Controller
    {
        //Admin Controller
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        //bu partial view sol menüyü tutacak
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
