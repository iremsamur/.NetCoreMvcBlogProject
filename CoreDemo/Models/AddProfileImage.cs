using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        //yazarın resim yüklemesi.
        //Writer entity'sinin tüm property'lerini buraya ekliyorum.
        //Writer Modeli
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }//dosyadan bir dosya değeri seçebilmeyi sağlar.
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterPasswordAgain { get; set; }

        public bool WriterStatus { get; set; }
    }
}
