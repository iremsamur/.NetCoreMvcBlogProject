using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : IGenericDal<Comment>
        //Bu şekilde Comment işlemlerinin olduğu Somut CommentRepository sınıfının IGenericDal'dan miras almasını sağladım.
        //ve içine T yerine Entity'de bulunan Comment sınıfını vererek bu interface'deki metodları Comment'a göre özelleştirmeyi
        //sağlarım.
        //Comment'a göre özelleştirilmiş işlemer
    {
        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Comment t)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
