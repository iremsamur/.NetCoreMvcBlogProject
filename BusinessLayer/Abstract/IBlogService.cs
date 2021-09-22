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

    }
}
