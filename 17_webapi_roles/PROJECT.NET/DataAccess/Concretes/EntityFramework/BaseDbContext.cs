using Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Core.Entities;

namespace DataAccess.Concretes.EntityFramework
{
    public class BaseDbContext : DbContext  // BaseDbContext, DbContext'ten inherit edililir. Bu sayede entityframeworkcore tarafından veritabanı gibi tanınması sağlanır.
        // Bu veritabanına nasıl bağlanılacak
        // Veritabanında hangi tablolar var
        // Hangi tablo hangi class'a karşılık geliyor gibi şeyleri burada configure ederiz
    {
        public DbSet<Category> Categories { get; set; }   // db'mizdeki category tablosunu tanımlıyoruz ve bunun bir entity, tablo olduğu bilinsin. (Tablo adını Categories olarak verdik)
        public DbSet<Product> Products { get; set; }    // db'mizdeki tabloyu tanımlıyoruz. (tablo adımız Products ve bu tablo Product'a karşılık geliyor)
        public DbSet<User> Users { get; set; }  // db'mizdeki Users isimli tabloyu tanımlıyoruz ve bu Users tablosu User entity'mize karşılık geliyor
        public DbSet<OperationClaim> OperationClaims { get; set; }  // core->entites içinde oluşturduğumuz tabloyu buraya ekliyoruz
        public DbSet<UserOperationClaim> UserOperationsClaims { get; set; }     // core->entites içinde oluşturduğumuz tabloyu buraya ekliyoruz

        // --- ÖNEMLİ NOT --- OLUŞTURDUĞUMUZ TABLOLARI public DbSet<> OLARAK EKLEDİKTEN SONRA MIGRATION İŞLEMİMİZİ YAPMAYI UNUTMUYORUZ... (Örneğin OperationClaim ve UserOperationClaim ekledikten sonra -> Package Manager Console açıyoruz ve Default Project'i DataAccess olarak seçiyoruz ve Add-Migration AddRoles olarak migration işlemimizi gerçekleştiriyoruz ama Core-> Entites içindeki BaseUser ismini baz almış ve tablo adımız olan User'ı BaseUser olarak değiştirmiş biz bunu istemiyoruz bu yüzden Remove-Migration yapıp bunu düzelteceğiz. biz BaseUser ismine sahip tablonun Users ismine sahip olmasını istiyoruz. Bu yüzden altta bu tablo adımınızın Users olmasını sağlıyoruz: modelBuilder.Entity<User>().ToTable("Users") ve ardından tekrar migration işlemimizi yapıyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   // OnConfiguring; ilgili db configure edilirken çalışan metod 
                            // OnModelCreating; ilgili db'nin altındaki modeller create edilirken çalışırken metod
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EGAQF63\\SQLEXPRESS;Initial Catalog=Database2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");  // SQL SERVER KULLAN DEMİŞ OLUYORUZ. Parantez içindekini connection stringi belirtmek için -> View -> SQL Server Object Explorer -> localdb sağ click -> sağ kısımda açılan properties'ten connection string karşısındaki değer alınır ve parantez içine yazılır. ** Catalog=Database ** Catalog karşısında database ismimizi yazmayı unutmuyoruz. Oluşturduğum database'in adı Database olduğu için bu şekilde yazdım. Örneğin db adı Ali olsaydı Catalog=Ali yazacaktık.

            // NOT: FIRST CODE İŞLEMLERİ GERÇEKLEŞTİRMEDEN ÖNCE EKSTRA OLARAK ÖNCE BİR CATEGORY OLUŞTURDUK VE BU KISIMDA DAHA ÖNCE DB ADIMIZ Database iken şuan Database2 olarak oluşturduk. Ve bu isimde herhangi bir veritabanımız şuan yok, bunu oluşturmak için buradaki konfigirasyonların geçerli olması için package manager console açmamız gerekiyor. Bu package manager console'u açmak için => View -> Other Windows -> Package Manager Console.

            // NOT2: Başlangıç projemiz WebAPI olacak ve package manager console'da seçilen default project DataAccess yani context'imizin bulunduğu proje (bu projede DataAccess) ve başlangıç projemiz client projemiz (bu projede WebAPI) olmalıdır.

            // NOT3: Package Manager Console'daki komutumuz Add-Migration "Migraton isimlendirmesi" (yani bizim db değişikliğimizlere bir geçmiş ekliyor, github commiti gibi düşünebiliriz). Bu projede migration isimlendirmesine Initial verdik. -> Add-Migration Initial

            // NOT3: Bu migration'ının db tarafında uygulanması için Update-Database komutunu giriyoruz. Ardından oluşturduğumuz Database2 yaratılacak ve products, categories tablolarımız oluşacak.

            // NOT4: Kodlarımızda yapıan her değişiklik sonrası migration işlemleri için:
            // 1- Add-Migration Migrationİsmi -> Örneğin bu projede product'a bir string ImgUrl alanı eklediğimizi düşünelim Add-Migration AddImgUrl_Product şeklinde komutumuzu giriyoruz
            // 2- Update-Database -> Migration'ın db'mize uygulanması için bu komutu giriyoruz.

            // NOT5: Son oluşturduğumuz migration işlemini geri almak için:
            // 1- Remove-Migration komutunu kullanıyoruz. Ama Migration işlemi eğer db'ye uygulanmışsa yani Update-Database komutu kullanılmışsa bu durumda öncelikle son bu db işlemini geri almalıyız. Yani ilk oluşturduğumuz Initial ismini verdiğimiz migration'a geri dönelim:
            //      - Update-Database -Migration Initial  -> yazıyoruz. Bu sayede db'mizi Initial isimli migration'a döndürmüş oluyoruz.
            //      - Remove-Migration -> komutu ile de Migrations klasörümüzde oluşan _AddImgUrl_Product isimli migration dosyamız silinmiş oluyor.
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Db için özel konfigürasyonları (veritabanı özelleştirmeleri) burada tanımlıyoruz (Tüm bu değişikliklerin uygulanması ve devreye girmesi için Migration işlemlerimizi yapmalıyız)
            modelBuilder.Entity<Product>().ToTable("ProductTable");     // Örneğin bu metod ile tablomuzun ismini ProductTable olarak değiştirebiliriz.
            modelBuilder.Entity<Product>().HasOne(p => p.Category);     // Örneğin her product bir kategoriye sahip diyebiliriz
            // Ayrıca property özelliklerini de değiştirebiliriz:
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("Name").HasMaxLength(50);  // Örneğin Name alanının max lenght'ini 50 yaptık.
            modelBuilder.Entity<User>().ToTable("Users");   // tablomuzun adını users yaptık

            // Spesifik konfigürasyonların yanında Seed Data da oluşturabiliriz. Seed Data dediğimiz ise veritabanımızın ilk oluşturulması veya yeniden oluşturulması sırasında varsayılan verilerin eklenmesi anlamına gelir. Yani, veritabanımız oluşturulduğunda veya güncellendiğinde, belirli tablolara önceden tanımlanmış verileri eklemek için kullanılır.

            Category category = new Category(1, "Giyim");             // Giyim isimli kategori oluşturduk
            Category category1 = new Category(2, "Elektronik");       // Elektronik isimli kategori daha oluşturduk
            Product product = new Product(1, "Kazak", 500, 50, 1);    // product oluşturduk

            modelBuilder.Entity<Category>().HasData(category, category1);   // oluşturduğumuz kategorileri ekledik
            modelBuilder.Entity<Product>().HasData(product);                // oluşturduğumuz product'ı ekledik

            // TÜM BU İŞLEMLERDEN SONRA MIGRATE EDIYORUZ Bu örneğimiz için: Add-Migration SeedData_Product_Category
            // ARDINDAN Update-Database komutunu uyguluyoruz

            // NOT: SEED DATA VERİTABANI TEST İŞLEMLERİ İÇİN UYGULANIR.

            base.OnModelCreating(modelBuilder);
        }
    }
}

// EN ÖNEMLİ NOT: CODE-FIRST VEYA DB-FIRST SEÇİMİ YAPARKEN EN DOĞRU SEÇİM -> TUTARLI SEÇİMDİR. YANİ EĞER BAŞLANGIÇTA DB-FIRST BAŞLADIYSAK BUNUNLA DEVAM EDERİZ VEYA BAŞLANGIÇTA CODE-FIRST BAŞLADIYSAK BUNUNLA DEVAM EDERİZ. İKİ YAKLAŞIMI BİRBİRİYLE KARIŞTIRMAYIZ ANCAK DAHA SONRADAN BUNLAR ARASINDA GEÇİŞ YAPABİLİRİZ. BURADA ESAS DEĞİNMEK İSTEDİĞİMİZ NOKTA ŞU: ÖRNEĞİN BİR PROJEDE 5 KİŞİ ÇALIŞIYOR VE CODE-FIRST İŞLEMLER YAPILIYORSA 3 KİŞİ CODE-FIRST ÇALIŞIP 2 KİŞİ DB-FIRST ÇALIŞMAMALIDIR. HERKES CODE-FIRST BAŞLANDIYSA CODE-FIRST ÇALIŞMALIDIR.
 