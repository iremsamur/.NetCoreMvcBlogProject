using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class NewsLetter
    {
        //Kullanıcıların mail bültenine abone olup gelen yeni haberleri bildirimleri görebileceği bir alan olacak.
        [Key]
        public int MailID { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
