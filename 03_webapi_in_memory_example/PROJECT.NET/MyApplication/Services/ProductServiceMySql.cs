using MyApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    public class ProductServiceMySql : BaseProductService
    {
        public override void AddProduct(Product product)     // SOMUT BİR İFADE --- ABSTRACT CLASS'TAN MİRAS ALDIĞIMIZ İÇİN override yazmamız gerekir
        {
            Console.Write("Ürün MySql veritabanına eklendi");
        }

        public override void UpdateProduct(Product product)  // SOMUT BİR İFADE --- ABSTRACT CLASS'TAN MİRAS ALDIĞIMIZ İÇİN override yazmamız gerekir
        {
            Console.Write("Ürün MySql veritabanında güncellendi");
        }
    }
}
