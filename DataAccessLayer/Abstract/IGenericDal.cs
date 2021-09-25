using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //Bununla bu T bir sınıfa ait tüm değerleri kullanabilsin dedik.

    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetById(int id);
        List<T> GetListAll(Expression<Func<T,bool>> filter);
        //Bu lambda expression kullanımı ile şarta göre listelemeyi sağlayacak olan metodu 
        //yazıyorum.
    }
}
