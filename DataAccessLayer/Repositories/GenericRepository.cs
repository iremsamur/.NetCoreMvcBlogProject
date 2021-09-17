using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //Böylece generic bir sınıf oluşturdum.
        //Her sınıfa entity için kullanılabilir.
        public void Delete(T t)
        {
            using var c = new Context();//Context c = new Context() kullanımının 2.bir kullanım şekli
            /*Bunun diğerinden farkı using kullanarak Context sınıfını tanımladığımız zaman çöp toplayıcıdan 
             * önce IDisposable arayüzünün dispose metodunun çalıştırılarak hafızadan silinmesini sağlar.*/
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);

        }

        public List<T> GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList(); //Buradaki generic olduğu için set controller kullanarak yazdım. 
            //Bu şekilde set'e bağlı olarak kullanmam gerekiyor
        }

        public void Insert(T t)
        {
            using var c = new Context();//Context c = new Context() kullanımının 2.bir kullanım şekli
            /*Bunun diğerinden farkı using kullanarak Context sınıfını tanımladığımız zaman çöp toplayıcıdan 
             * önce IDisposable arayüzünün dispose metodunun çalıştırılarak hafızadan silinmesini sağlar.*/
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();//Context c = new Context() kullanımının 2.bir kullanım şekli
            /*Bunun diğerinden farkı using kullanarak Context sınıfını tanımladığımız zaman çöp toplayıcıdan 
             * önce IDisposable arayüzünün dispose metodunun çalıştırılarak hafızadan silinmesini sağlar.*/
            c.Update(t);
            c.SaveChanges();
        }
    }
}
