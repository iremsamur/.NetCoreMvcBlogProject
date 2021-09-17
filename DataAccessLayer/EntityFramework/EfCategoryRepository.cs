using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal //Category sınıfıyla çalıştığımız için , 
        //bu sınıf hem GenericRepository hemde ICategoryDal 'dan miras alır.
        //Böylece Entity Framework sınıfı ICategory ve GenericRepository deki tüm metodları kullanabilir hale geldi.
        //Burada çoklu kalıtım oldu 
        //içine Category alır. Buna göre çalışır.
    {
        //Bu sınıf GenericRepository sınıfından miras alır
    }
}
