using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // T = Type'ın kısaltmasıdır. T yerine <Type> veya istediğimizi yazabiliriz ama Type'ın kısaltması olan <T> şeklinde yazmak best practice'dir.
    public interface IRepository<T>     // Tüm yapılarda ortak kullanacağımız generic yapıyı oluşturuyoruz ve bunu ICategoryRepository, IProductRepository içinde miras alacağız. Bu sayede kod tekrarını önleyemiş olacağız. Ayrıca bu metodları artık entity'lerin herbirine ayrı ayrı yazmamış olacağız 
    {
        T? GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
