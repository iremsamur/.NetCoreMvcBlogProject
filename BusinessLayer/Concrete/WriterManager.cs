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
    //Writer register için
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetList()
        {
            //bu admin panelinde tüm yazarları listelerken kullanılır.

            throw new NotImplementedException();
        }

        public List<Writer> GetWriterByID(int id)
        {
            return _writerDal.GetListAll(x => x.WriterID == id);//id'ye göre yazarları listelesin
            
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public void TUpdate(Writer t)
        {
            //yazar bilgilerini güncelleme
            _writerDal.Update(t);
        }

    }
}
