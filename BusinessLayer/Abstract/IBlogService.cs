using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        //Blog işlemleri
        //Blog için generic yapıyı kuruyoruz.

        //void BlogAdd(Blog blog);
        //void BlogUpdate(Blog blog);
        //void BlogDelete(Blog blog);
        //List<Blog> GetList();
        //Blog GetById(int id);

        //Blog sınıfının kendine özel metodları kalıyor
        List<Blog> GetBlogListWithCategory(); //include metodunu yazdığım bu metodu UI içinde kullanmak için yeni eklediğim metodu 
        //burada da yazdım.
        //Blogları yazarlar ile getirsin
        List<Blog> GetBlogListWithWriter(int id);

    }
}
