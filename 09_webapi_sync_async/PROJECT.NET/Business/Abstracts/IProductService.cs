using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService    // Servislerin bulunduğu soyut sınıfı(interface) oluşturduk ve buna karşılık gelen somut sınıf olan manager'ı oluşturmalıyız
    {
        Product GetById(int id);        // TEK BAŞINA BİR PRODUCT DÖNEN GETBYID METODU
        Task<List<Product>> GetAll();         // PRODUCT SINIFINDAN OLUŞAN BİR LİSTE DÖNDÜRÜR. GETALL METODU ÇAĞRILDIĞINDA PRODUCT LİSTESİ DÖNDÜRÜLÜR
        void Add(Product product);      // ADD METODU
        void Update(Product product);   // UPDATE METODU
        void Delete(int id);            // DELETE METODU
    }
}
