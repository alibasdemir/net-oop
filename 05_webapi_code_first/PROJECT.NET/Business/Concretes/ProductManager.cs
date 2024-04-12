using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService   // Soyut sınıf olan IProductService(interface)'in karşılığı olan somut sınıf ProductManager oluşturulur ve bu sınıf IProductService'den kalıtım alınır. Implemente ettikten sonra metodlar yazılır
    {

        IProductRepository _productRepository;      // burada isimlendirme kuralında class içindeki global değişkenler c#'da alt tire ile yazılır

        // DEPENDENCY INJECTION YAPARKEN HER ZAMAN AKLIMIZA ŞU SORU GELMELİ: BU SERVİS, SERVİSLER ARASINA EKLENDİ Mİ?

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            if(product.UnitPrice < 0)
            {
                throw new Exception("Ürün fiyatı 0'dan küçük olamaz");
            }

            _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            // Cacheleme yapılıyorsa cahce'den gelsin gibi bir kural yazılabilir.
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
