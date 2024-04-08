using Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace DataAccess.Concretes.EntityFramework
{
    public class BaseDbContext : DbContext  // BaseDbContext, DbContext'ten inherit edililir. Bu sayede entityframeworkcore tarafından veritabanı gibi tanınması sağlanır.
        // Bu veritabanına nasıl bağlanılacak
        // Veritabanında hangi tablolar var
        // Hangi tablo hangi class'a karşılık geliyor gibi şeyleri burada configure ederiz
    {
        public DbSet<Product> Products { get; set; }    // db'mizdeki tabloyu tanımlıyoruz. (tablo adımız Products ve bu tablo Product'a karşılık geliyor)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   // OnConfiguring; ilgili db configure edilirken çalışan metod 
                            // OnModelCreating; ilgili db'nin altındaki modeller create edilirken çalışırken metod
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EGAQF63\\SQLEXPRESS;Initial Catalog=Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");  // SQL SERVER KULLAN DEMİŞ OLUYORUZ. Parantez içindekini connection stringi belirtmek için -> View -> SQL Server Object Explorer -> localdb sağ click -> sağ kısımda açılan properties'ten connection string karşısındaki değer alınır ve parantez içine yazılır. ** Catalog=Database ** Catalog karşısında database ismimizi yazmayı unutmuyoruz. Oluşturduğum database'in adı Database olduğu için bu şekilde yazdım. Örneğin db adı Ali olsaydı Catalog=Ali yazacaktık.
            base.OnConfiguring(optionsBuilder);
        }
    }
}
 