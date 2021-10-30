using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        //constructor injection
        public BlogManager(IBlogDal blogDal)
        {
            this._blogDal = blogDal;
        }

        //Eski generic olmayandan kalan metodları yorum satırı yapalım
        //public void BlogAdd(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogDelete(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogUpdate(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Blog> GetBlogListWithCategory()
        {
            //Burada şimdi metodumu çağırıyorum.
            return _blogDal.GetListWithCategory();
        }

        public Blog TGetById(int id)
        {

            return _blogDal.GetById(id);
        }

        //Şartlı listeleme için
        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }
        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
        //footer alanında sadece son 3 blogu getirmesi için metod
        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();//burada take metodunu kullanarak sadece 3 adet veri getirmesini sağlarım
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Blog t)
        {
            //Blog ekleme
            _blogDal.Insert(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);//Burada t parametresi karşılığı blogvaluedan gelen değer.blogvalue 'da blogcontroller'da
        }
        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
    }
}
