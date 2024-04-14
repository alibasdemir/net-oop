using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        List<Product> products;

        public InMemoryProductRepository()
        {
            products = new List<Product>();
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Delete(Product product)
        {
            products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            // LINQ ==> SQL'İN C# HALİ. veriye erişmek için SQL benzeri ifadeler kullanmamıza olanak tanır
            return products.Where(p => p.Id == id).FirstOrDefault();  // (p => p.Id == id) bu yapıyı (predicate denir) foreach gibi düşünebiliriz yani bütün productları gez p ismini ver p'nin id'si gelen id değerine eşit olanları filtrele FirstOrDefault(); ise bu filtreye ilk uyan değer veya default değeri 

            // VEYA ALTTAKİ ŞEKİLDE DE KULLANABİLİRİZ
            // return products.FirstOrDefault(p => p.Id == id);
            // FirstOrDefault'ta değer bulunmadığında default oluyor.
            // Genellikle bu yapı daha çok kullanılır

            // VEYA ALTTAKİ ŞEKİLDE DE KULLANABİLİRİZ
            // Product? product = products.FirstOrDefault(p => p.Id == id);
            // return product;

            // VEYA ALTTAKİ ŞEKİLDE DE KULLANABİLİRİZ
            // Product? product = products.Find(p => p.Id == id);
            // return product;
            // bu yapıda değer bulunmadığında null oluyor.
        }

        public void Update(Product product)
        {
            // InMemory çalıştığımız için şimdilik atlıyoruz.
        }
    }
}
