using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterPasswordAgain { get; set; }

        public bool WriterStatus { get; set; }
        //Writer Blog ilişkisi
        public List<Blog> Blogs { get; set; }

        //Writer Ve Message İlişkisi - 2 foreign key'li ilişki için
        public virtual ICollection<Message2> WriterSender { get; set; }//Gönderici için WriterMessage ilişkisi
        public virtual ICollection<Message2> WriterReceiver { get; set; } //alıcı için WriterMessage ilişkisi

    }
}
