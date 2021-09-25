using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal //Bloga göre çalışır.
    {
        public List<Blog> GetListWithCategory()
        {
            //Blogları kategori adı ile birlikte kullanabilmek için interface'deki bu metodu gövdesini burada yazarım
            //Include metodunu kullanıyorum.
            using(var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).ToList(); //Bu Include metodunu yazmış oldum.
            }
        }
    }
}
