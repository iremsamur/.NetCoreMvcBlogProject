using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService //Bu ICategoryService'dan miras alır. Çünkü interface'lerim burada.
    {
        //Metodları implemente ettim.
        //şimdi  bu metodların içini dolduralım.
        //CategoryRepository categoryRepository = new CategoryRepository();//Craud metodlarını burada oluşturmuştum.
        //Bu olmaması gereken bir yöntemdir. Çünkü tamamen generic olması gerektiğini söylemiştik

        //2.yol GenericRepository Kullanma
        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //3.yol - SOLID için kullanılması gereken doğru yol budur. Oluşturduğumuz EfCategoryRepository'den bir değer tanımlayalım
        ICategoryDal _categoryDal;
        //Şimdi CategoryManager sınıfına atamak yapmak için Constructor metod oluşturmam gerekiyor.
        /*
        public CategoryManager()
        {
            efCategoryRepository = new EfCategoryRepository();//Bu şekilde new'leme işlemini bu constructor metod içerisine yazdım.
        }
        */

        public CategoryManager(ICategoryDal categoryDal) //constructor injection yaptım.
        {
            _categoryDal = categoryDal;
        }

        //public void CategoryAdd(Category category)
        //{
        //_categoryDal.Insert(t);//Burada _categoryDal diyerek de bu interface'i miras alan generic repository 
        //    //sınıfını kullanabiliyorum
        //    //içindeki metodlara erişim sağlayabiliyorum.

        //}

        //public void CategoryDelete(Category category)
        //{
        //    _categoryDal.Delete(category);

        //}

        //public void CategoryUpdate(Category category)
        //{
        //    _categoryDal.Update(category);
        //}

        //public Category GetById(int id)
        //{
        //    return _categoryDal.GetById(id);

        //}

        //public List<Category> GetList()
        //{
        //    return _categoryDal.GetListAll();
        //}

        //Generic yapıya göre düzenlediğim metodlar

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);

        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);//Burada _categoryDal diyerek de bu interface'i miras alan generic repository 
            //sınıfını kullanabiliyorum
            //içindeki metodlara erişim sağlayabiliyorum.
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

        
    }
}
