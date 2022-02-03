using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Biz bu confire metodu içinde veritabanına bağlantı stringimizi tanımlarız.
            //Tanımladığımız bu connection Stringin türü DbContextOptionsBuilder'dır
            //Yani conection stringimi .Net core da bu şekilde tanımlayabilirim.
            optionsBuilder.UseSqlServer("server=LAPTOP-ISO96UVH\\SQLEXPRESS;database=CoreBlogDb;integrated security=true;");
            //Veritabanı bağlantı stringimi bu şekilde tanımlarım.

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }

        public DbSet<Notification> Notifications { get; set; }

    }
}
