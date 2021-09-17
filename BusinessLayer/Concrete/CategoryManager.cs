using BusinessLayer.Abstract;
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
        EfCategoryRepository efCategoryRepository;
        //Şimdi CategoryManager sınıfına atamak yapmak için Constructor metod oluşturmam gerekiyor.
        public CategoryManager()
        {
            efCategoryRepository = new EfCategoryRepository();//Bu şekilde new'leme işlemini bu constructor metod içerisine yazdım.
        }
        public void CategoryAdd(Category category)
        {
            efCategoryRepository.Insert(category);

        }

        public void CategoryDelete(Category category)
        {
            efCategoryRepository.Delete(category);

        }

        public void CategoryUpdate(Category category)
        {
            efCategoryRepository.Update(category);
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);

        }

        public List<Category> GetList()
        {
            return efCategoryRepository.GetListAll();
        }
    }
}
