using MyApplication.Entities;
using MyApplication.Services;

Product product = new Product();
product.Name = "Masa";
product.UnitPrice = 50;
product.Id = 1;

   
BaseProductService productService = new ProductServiceMSSQL();     // Yine bir polymorphism kullanımı
productService.AddProductWithLogging(product); //Loglama işlemi ezildi --- Ürün MSSQL veritabanına eklendi

BaseProductService productService1 = new ProductServiceMySql();    // Yine bir polymorphism kullanımı
productService1.AddProductWithLogging(product); // Loglama işlemi yapıldı --- Ürün MySql veritabanına eklendi