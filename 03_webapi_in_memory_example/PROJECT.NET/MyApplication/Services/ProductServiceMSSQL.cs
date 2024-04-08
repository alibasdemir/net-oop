using MyApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    // SERVICES KLASÖRÜ İŞÇİ SINIFLARINI TUTAR. PRODUCT'IN METODLARI BURADA TUTULUR.
    public class ProductServiceMSSQL : BaseProductService   // ABSTRACT CLASS'TAN MİRAS ALIYORUZ
    {
        public override void AddProductWithLogging(Product product)
        {
            Console.WriteLine("Loglama işlemi ezildi");
            AddProduct(product);
        }
        public override void AddProduct(Product product)     // SOMUT BİR İFADE --- ABSTRACT CLASS'TAN MİRAS ALDIĞIMIZ İÇİN override yazmamız gerekir
        {
            Console.WriteLine("Ürün MSSQL veritabanına eklendi");
        }

        public override void UpdateProduct(Product product)  // SOMUT BİR İFADE --- ABSTRACT CLASS'TAN MİRAS ALDIĞIMIZ İÇİN override yazmamız gerekir
        {
            Console.WriteLine("Ürün MSSQL veritabanında güncellendi");
        }
    }
}
