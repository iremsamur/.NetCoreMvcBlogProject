using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        //Erişim Belirleyici Türü - Değişken Türü - İsim - { get set}
        //prop+2tab = property
        [Key]
        public int CategoryID { get; set; }
        public string  CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }//ilişkili tablolarda silme işlemi sorun olduğu için 
        //tablodan değer silmek yerine CategoryStatus ile durum değiştireceğiz. Yani Aktif ya da pasif yapacağız.

    }
}
