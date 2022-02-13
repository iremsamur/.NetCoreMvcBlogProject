﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()//Gönderilen Mesajlar
        {
            int id = 10;
            var values = messageManager.GetInBoxListByWriter(id);
            return View(values);
        }

        //Mesaj detayları alanı
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {

            var value = messageManager.TGetById(id);

            
            return View(value);
        }
    }
}
