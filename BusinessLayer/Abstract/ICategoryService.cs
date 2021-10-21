using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>//entity'e göre çalış diyorum
    {
        //Generic repositoryden dolayı artık buradaki metodlara ihtiyacım yok

        //Manager'lar için interface
        //Category sınıfı için Business metodları, Kategori bölümü işlemleri için
        //void CategoryAdd(Category category);//Category sınıfını burada kullanabilmek için Business katmanına önceden 
        ////EntityLayer katmanınını referansını vermiştik.
        //void CategoryUpdate(Category category);
        //void CategoryDelete(Category category);
        //List<Category> GetList();
        //Category GetById(int id);


    }
}
