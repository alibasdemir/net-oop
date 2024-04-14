using MyApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    // ABSTRACT CLASS // YARI SOYUT SINIFLARDIR. INTERFACE'LERI MİRAS ALABİLİRLER VE SOMUT VEYA SOYUT METODLAR TUTABİLİRLER. SOYUTLAR İÇİN public abstract void yazılır.
    public abstract class BaseProductService : IProductService  // INTERFACE'DEN MİRAS ALIYORUZ
    {
        public virtual void AddProductWithLogging(Product product)      // somut ---> virtual ezebebilirsin anlamı taşır. örneğin "Loglama işlemi yapıldı" çıktısını MSSQL'de ezelim ve "Loglama işlemi ezildi" çıktısını alalım. Ayrıca alttaki body'i ezeceğimiz için AddProduct(product); eklemenmiz gerekir. Çünkü body tamamen ezilecek, eğer AddProduct metodunu MSSQL de belirtmezsek ezildiği için çalışmayacak.
        {
            Console.WriteLine("Loglama işlemi yapıldı");
            AddProduct(product);
        }
        public abstract void AddProduct(Product product);        // soyut

        public abstract void UpdateProduct(Product product);     // soyut 

    }
}
