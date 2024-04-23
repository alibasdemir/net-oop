using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // NOT: CORE PAKETİ BAĞIMSIZ OLMALIDIR. YANİ DİĞER TÜM PAKETLERE(DataAccess, Business, Entities) REFERANS DAĞITABİLİR ANCAK HİÇ BİR PAKETTEN REFERANS ALAMAZ. Peki burada somut olan Ef dosyalarımızı alırken içinde bulunan bağımlı olan BaseDbContext'i nasıl Core paketinde referans almadan, diğer paketlere bağımlı olmadan yazacağız, işte bu durumda T belirtirken sadece entity değil contexti de generic yapabiliriz
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>, IAsyncRepository<TEntity>   // Entity ve Context yapılarımızı 2 tane olacak şekilde generic yapabiliriz. Bu şekilde context'e bağımlı olmadan context kullanabiliyoruz. IRepository<TEntity> ---> Ayrıca EfRepositoryBase'imiz de IRepository kullanacak ve TEntity'i gönderecek çünkü IRepository bizden bir entity türü bekliyor. Generic yapı bu şekilde de kullanılabiliyor, dışarıdan alıp başka yere aktarabiliyoruz. IRepository<TEntity> aldıktan sonra implemente ediyoruz. Ve implemente ettiğimiz metodları tüm yapılar için çalışacak şekilde ortak kurgulamamız gerekiyor
        where TContext : DbContext      // TContext'e DbContext gibi davran diyoruz
        where TEntity : Entity          // TEntity'e Entity gibi davran diyoruz
    {
        private readonly TContext Context;   // Contexti DI (dependency injection) olacak şekilde burada entegre ettik. DI olarak entegre ediyorsak readonly yazmayı unutmuyoruz. Çünkü bunun set edilmesini istemeyiz. Sadece okumasını isteriz bu yüzden readonly yaparız
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            // Örneğin bu kısımda EfProductRepository ve EfCategoryRepository için context.Categories.Add(category); context.SaveChanges(); ve context.Products.Add(product); context.SaveChanges(); yazdık ama buraya örneğin context.SaveCahanges(); yazmaya çalıştığımızda bunu yazamıyoruz. Çünkü biz burda bir TContext bekliyoruz ama burda sistem TContext'in tipini bilmiyor. Yani DbContext'miş gibi davranıp bize onun fonksiyonlarını ya da değerlerini çıkaramaz. Bu durumlarda biz generic type'lara Constraints verebiliriz. Yani kısıtlar. (Generic olsun, kullanıcı istediğini versin ama bizim belirlediğimiz sınırlar, kısıtlar içinde). where TContext : DbContext ekleyerek ve Core paketini kurarak artık TContext'in DbContext gibi davranmasını sağlayabiliriz ve Context.Add, delete, update gibi metodları istediğimiz gibi kullanabiliriz.

            Context.Add(entity);    // EfProductRepository ve EfCategoryRepository de ki gibi özellikle Categories.Add veya Products.Add şeklinde tablo ismi belirtmemize gerek yok. Core paket Generic yapılarla uyumlu şekilde çalışabildiği için bunu otomatik olarak kendisi tanıyor. Bu yüzden belirtmemize gerek kalmadan direkt .Add yazıp entity'i göndermemiz yeterli olacaktır.
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();

        }

        public TEntity? Get(Expression<Func<TEntity, bool>>? predicate = null)   // artık Get IRepository.cs'de ki gibi bir imzaya sahip bu yüzden burayı güncelledik. Null eğer varsayılan bir değer gönderilmemişse varsayılan değerdir.
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();
                
            return data.FirstOrDefault(predicate);                       
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate)     // artık GetList IRepository.cs'de ki gibi bir imzaya sahip bu yüzden burayı güncelledik.
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();  // IQueryable üzerine query yazılabilen bir tiptir. veri setimizi bu tipte ele alabiliriz

            if(predicate != null)
                data = data.Where(predicate);                   // predicate boş değilse yani filtrelenmişse filtrelenmiş datayı getir

            return data.ToList();                               // eğer boşsa filtrelenmemiş datayı getir
        }

        public void Update(TEntity entity)
        {  
            Context.Update(entity);
            Context.SaveChanges();
        }

        // --- ASENKRON İŞLEMLER ---

        public async Task AddAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Remove(entity);         // DELETE İŞLEMİNDE REMOVE KISMINI ASENKRON YAPMAYA GEREK YOKTUR.
            await Context.SaveChangesAsync();
        }
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            return await data.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (predicate != null)
                data = data.Where(predicate);
            return await data.ToListAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);         // UPDATE İŞLEMİNDE UPDATE KISMINI ASENKRON YAPMAYA GEREK YOKTUR.
            await Context.SaveChangesAsync();
        }
    }
}
