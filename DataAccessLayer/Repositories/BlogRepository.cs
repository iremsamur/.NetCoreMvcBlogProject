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
    public class BlogRepository : IBlogDal
    {
        //IBlogDal interface'inin sınıf karşılığı
        
        public void AddBlog(Blog blog)
        {
            using var c = new Context();//Context c = new Context() kullanımının 2.bir kullanım şekli
            /*Bunun diğerinden farkı using kullanarak Context sınıfını tanımladığımız zaman çöp toplayıcıdan 
             * önce IDisposable arayüzünün dispose metodunun çalıştırılarak hafızadan silinmesini sağlar.*/
            c.Add(blog);
            c.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            using var c = new Context();//Context c = new Context() kullanımının 2.bir kullanım şekli
            /*Bunun diğerinden farkı using kullanarak Context sınıfını tanımladığımız zaman çöp toplayıcıdan 
             * önce IDisposable arayüzünün dispose metodunun çalıştırılarak hafızadan silinmesini sağlar.*/
            c.Remove(blog);
            c.SaveChanges();
        }

        public Blog GetById(int id)
        {
            using var c = new Context();
            return c.Blogs.Find(id);
        }

        public List<Blog> ListAllBlog()
        {
            using var c = new Context();//Context c = new Context() kullanımının 2.bir kullanım şekli
            /*Bunun diğerinden farkı using kullanarak Context sınıfını tanımladığımız zaman çöp toplayıcıdan 
             * önce IDisposable arayüzünün dispose metodunun çalıştırılarak hafızadan silinmesini sağlar.*/
            return c.Blogs.ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            using var c = new Context();//Context c = new Context() kullanımının 2.bir kullanım şekli
            /*Bunun diğerinden farkı using kullanarak Context sınıfını tanımladığımız zaman çöp toplayıcıdan 
             * önce IDisposable arayüzünün dispose metodunun çalıştırılarak hafızadan silinmesini sağlar.*/
            c.Update(blog);
            c.SaveChanges();
        }
    }
}
