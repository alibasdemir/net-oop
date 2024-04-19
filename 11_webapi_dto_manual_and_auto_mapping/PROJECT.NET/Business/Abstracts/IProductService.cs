using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
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
        Task<List<ListProductResponse>> GetAll();     // DTO --->> Ürün listelenirken Product yerine ListProductResponse yazdık
        Task Add(AddProductRequest dto);      // ADD METODU ---> metodu async yazdığımız için Task yaptık. --> ARTIK KULLANICADAN İSTEYECEĞİMİZ BİLGİLERİ İÇEREN DTO'yu yazdık "AddProductRequest"
        void Update(Product product);   // UPDATE METODU
        void Delete(int id);            // DELETE METODU
    }
}
