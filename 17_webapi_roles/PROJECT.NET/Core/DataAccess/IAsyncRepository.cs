using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IAsyncRepository<T>
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);   // EfRepositoryBase içinde include parametresi eklediğimiz için parametreyi buraya da eklememiz gerekiyor
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);  // EfRepositoryBase içinde include parametresi eklediğimiz için parametreyi buraya da eklememiz gerekiyor
        Task AddAsync(T entity);        // senkron yapıdaki "void" asenkron yapıda düz Task olarak yazılır. Ayrıca bu kısımları async olarak işaretlememiz gerekmez çünkü async işareti sadece somut yapılarda kullanılır 
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
