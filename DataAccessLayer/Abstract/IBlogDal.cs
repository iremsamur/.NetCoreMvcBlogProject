using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        //Blog Sınıfı için interface
        /*Generic'de zaten bu metodları yazdığım için burada tekrar yazmama gerek yok. Bunları kullanmıyorum.
         * // O yüzden silmek yerine yorum satırına aldım. Bunun için IGenericDal interface'inden bu interface'in miras almasını
         sağladım.*/
        /*
        List<Blog> ListAllBlog();
        void AddBlog(Blog blog);
        void DeleteBlog(Blog blog);//silme
        void UpdateBlog(Blog blog);//güncelleme
        //id'ye göre veri getirebilme metodu, id'ye göre güncelleme silme işlemi yapabilmem için gerekli 
        Blog GetById(int id);
        */

        /*Normalde bu interface'im IGenericDal içindeki tüm metodları kullanabiliyor. Bu IGenericDal Metodları tüm sınıflar için ortak metodlardır.
         Ama şimdi ben bu interface için özel olan sadece bunun için geçerli olan Include metodunu buraya yazarım.*/
        List<Blog> GetListWithCategory();//Bu metodu include metodu için bunu yazarım. Yani blogları ilişkili olduğu tablo olan Category tablosundaki
                                         //Category adı ile birlikte getirebilmesini sağlar.

        //blogları yazara göre kategorisi ile birlikte getirsin dedik.

        List<Blog> GetListWithCategoryByWriter(int id);
        
    }
}
