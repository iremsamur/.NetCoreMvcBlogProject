using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        //Yorum işlemleri
        void CommentAdd(Comment comment);
        //EntityLayer katmanınını referansını vermiştik.
        //void CommentUpdate(Comment comment);
        //void CommentDelete(Comment comment);
        List<Comment> GetList(int id);
        //Comment GetById(int id);
    }
}
