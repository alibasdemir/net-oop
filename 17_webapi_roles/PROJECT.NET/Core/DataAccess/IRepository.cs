using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // T = Type'ın kısaltmasıdır. T yerine <Type> veya istediğimizi yazabiliriz ama Type'ın kısaltması olan <T> şeklinde yazmak best practice'dir.
    public interface IRepository<T>     // Tüm yapılarda ortak kullanacağımız generic yapıyı oluşturuyoruz ve bunu ICategoryRepository, IProductRepository içinde miras alacağız. Bu sayede kod tekrarını önleyemiş olacağız. Ayrıca bu metodları artık entity'lerin herbirine ayrı ayrı yazmamış olacağız 
    {
        T? Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);  // EfRepositoryBase içinde include parametresi eklediğimiz için parametreyi buraya da eklememiz gerekiyor
        List<T> GetList(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);   // (Lambda expression) (Func<in T, out TResult>)Expression bir fonksiyon gönderecek, bu fonksiyon parametre olacak T alacak ve boolean çıkaracak. bununda ismine genellikle predicate diyoruz. Yani filtre, kalıp gibi düşünebiliriz. Filtre getirilmediği zaman hepsini getirmek için ? işaretini kullanıyoruz. Null ise eğer varsayılan bir değer gönderilmemişse varsayılan değerdir. --- EfRepositoryBase içinde include parametresi eklediğimiz için parametreyi buraya da eklememiz gerekiyor
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
