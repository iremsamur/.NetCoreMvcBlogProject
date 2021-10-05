using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        //Blog işlemleri
        void BlogAdd(Blog blog);
        void BlogUpdate(Blog blog);
        void BlogDelete(Blog blog);
        List<Blog> GetList();
        Blog GetById(int id);
        List<Blog> GetBlogListWithCategory(); //include metodunu yazdığım bu metodu UI içinde kullanmak için yeni eklediğim metodu 
        //burada da yazdım.
        //Blogları yazarlar ile getirsin
        List<Blog> GetBlogListWithWriter(int id);

    }
}
