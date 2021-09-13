using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; } //Blogun küçük resmi - Kapak fotoğrafı gibi
        public string BlogImage { get; set; } //Blogun büyük resmi
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }



    }
}
