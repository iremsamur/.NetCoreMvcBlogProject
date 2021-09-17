using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>//Category sınıfı için çalışacak.

        /*Generic'de zaten bu metodları yazdığım için burada tekrar yazmama gerek yok. Bunları kullanmıyorum.
         * // O yüzden silmek yerine yorum satırına aldım. Bunun için IGenericDal interface'inden bu interface'in miras almasını
         sağladım.*/
    {
        /*
        //interface'ler isimlendirilirken c# da başında IsınıfadıDal şeklinde olur. Dal - Data Access Layer katmanını temsil eder.
        //Bu interface Category bölümü için gerekli işlemlerin method gövdelerini tutacak.
        List<Category> ListAllCategory();//Kategorileri listeleyecek metodu List içine Category tablosunun 
        //karşılığı olan Category sınıfını alır. Türü Category olur.
        void AddCategory(Category category);//İçine yeni bir kategori ekleneceği için içine Category türünden parametre verdim.
        void DeleteCategory(Category category);//silme
        void UpdateCategory(Category category);//güncelleme
        //id'ye göre veri getirebilme metodu, id'ye göre güncelleme silme işlemi yapabilmem için gerekli 
        Category GetById(int id);
        */



    }
}
