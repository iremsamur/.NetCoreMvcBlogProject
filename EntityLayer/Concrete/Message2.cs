using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int messageID { get; set; }
        
        public int? SenderID { get; set; }//Sender ve receiver'ı burada ilişki yoluyla kullanacağız. Message ve Writer arasında
        //ilişki olacak ve sender ve receiver olarak 2 tane foreign key olacak.
        public int? ReceiverID { get; set; }
        public string subject { get; set; }
        public string messageDetails { get; set; }
        public DateTime messageDate { get; set; }
        public bool messageStatus { get; set; }//mesaj okundu okunmadı bilgisi için olacak.

        //Writer Message 2 foreign key ilişkisi tanımlamaları
       public Writer SenderUser { get; set; }//Gönderici
        public Writer ReceiverUser { get; set; }//Alıcı


    }
}
