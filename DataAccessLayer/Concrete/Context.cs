using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Biz bu confire metodu içinde veritabanına bağlantı stringimizi tanımlarız.
            //Tanımladığımız bu connection Stringin türü DbContextOptionsBuilder'dır
            //Yani conection stringimi .Net core da bu şekilde tanımlayabilirim.
            optionsBuilder.UseSqlServer("server=LAPTOP-ISO96UVH\\SQLEXPRESS;database=CoreBlogDb;integrated security=true;");
            //Veritabanı bağlantı stringimi bu şekilde tanımlarım.

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //entitiyler arasındaki 1'e çok ilişki dışındaki çoka çok, 2 foreign key'li ilişkileri burada
            //tanımlamamız gerekir. Bunu ModelBuilder sınıfını kullanarak yaparız.

            //Gönderici için

            modelBuilder.Entity<Message2>()//Message2 tablosundaki foreign keyler için ilişki kurulacak demek
                .HasOne(x => x.SenderUser)//Message sınıfındaki ilişki kurulacak değer.
                .WithMany(y => y.WriterSender)//Writer sınıfındaki message sınıfındaki değerle ilişki kurulacak değerin karşılığı olan değer
                .HasForeignKey(z => z.SenderID)//message sınıfındaki gönderici id değeri gelecek. Yani foreign key olacak olan değer.
                .OnDelete(DeleteBehavior.ClientSetNull);//İlişkili tabloda silme işlemi yaparken nasıl davranacağını belirtiyoruz.
            //şimdi aynı işlemi Alıcı için yapalım
            modelBuilder.Entity<Message2>()//Message2 tablosundaki foreign keyler için ilişki kurulacak demek
                .HasOne(x => x.ReceiverUser)//Sender için yapılan işlemleri receiver içinde yazıyorum.
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);//Başlangıçta model creater'ı oluştururken varsayılan kendi verdiği komutu buraya ekliyorum.
                

            //HomeMatches ---> WriterSender 
            //AwayMatches ---> WriterReceiver 

            //HomeTeam ---> SenderUser
            //HuestTeam ---> ReceiverUser


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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
