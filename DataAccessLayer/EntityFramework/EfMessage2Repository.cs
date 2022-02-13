using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            //İlişkili tablolarla mesajı atan yazarın adının getirilmesi
            //Include metodunu kullanıyorum.
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList(); //Bu Include metodunu yazmış oldum.
                //Alıcıya gelen mesajları listelemek için ReceiverId değeri dışardan bana gönderilen 
                //yani alıcı kimse o alıcının id'sine eşit olan göndericinin değerlerini bana getir demiş olduk.SenderUser burada foreign key
                //yani ilişkili
                //Writer'dan gelen gönderici değerdir. Yani ReceiverID bu id değeri dışardan gelene eşit olanı yani sadece
                //o alıcının mesajlarını listelemeyi sağlar.
            }
        }
    }

}
