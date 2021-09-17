using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        //şuanda bu repository generic değil
        Context context = new Context();
        public void AddCategory(Category category)
        {
            //Entity Framework Core Metodları
            context.Add(category);//ekleme işlemi
            context.SaveChanges();
            /*
             Entity Framework'deki kullanılan SaveChanges kullanımının  
            ADO.NET'deki karşılığı nedir ? ADO.NET Karşılığı ExecuteNonQuery() kullanımı olur.*/
        }

        public void DeleteCategory(Category category)
        {
            context.Remove(category);
            context.SaveChanges();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);//id'ye göre Bul demektir
        }

        public List<Category> ListAllCategory()
        {
            return context.Categories.ToList();//Kategori listeleme işlemi olduğu için Category sınıfının
                                               //veritabanındaki karşılığı olan Categories'e göre listeleme yapar
        }

        public void UpdateCategory(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
    }
}
