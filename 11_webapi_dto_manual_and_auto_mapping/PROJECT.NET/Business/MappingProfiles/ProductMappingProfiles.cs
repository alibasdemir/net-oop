using AutoMapper;
using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class ProductMappingProfiles : Profile      // iki nesne arasında mapleme yapılacak ama bu nesneleri tanımlamamız gerekiyor, hangi nesneyle hangi nesne arasında bir ilişki var. bunu yapabilmemiz için classımızı automapper'dan gelen Profile'dan inherit ediyoruz ve ctor içinde bu profil kurallarını tanımlıyoruz
    {
        public ProductMappingProfiles()
        {
            CreateMap<AddProductRequest, Product>();    // Yani Product ile AddProductRequest arasında bir mapleme olacak diye ekliyoruz. Sola ve sağa yazdığımız entity'lerin sırası önemlidir. <TSource, Tdestination> Soldaki kaynak, sağdaki hedef. Kaynak verileri alacağımız yer, hedef ise aldığımız kaynaktan üreteceğimiz class. Yani burada biz AddProductRequest'den Product üreteceğiz bu yüzden solda AddProductRequest sağda ise Product yer almalıdır. veya diğer yazım şekli olarak şöyle de yazabiliriz: 
            // CreateMap<Product, AddProductRequest>().reverseMap();   // ---> yani sağdan sola mapleme işlemini yap

            // Product.cs ve AddProductRequest.cs alanları içindeki isimler aynıysa oto maplenir. Ancak isimlerin farklı olduğu durumda iki alan arası mapleme yapmak istiyorsak özel konfigürasyonlar oluşturmamız gerekir. Örneğin AddProductRequest alanındaki UnitPrice'ın Price olduğunu düşünelim ve Product alanında UnitPrice olarak kaldığını düşünelim. Bu durumda ek konfigürasyon yazmalıyız:
            // CreateMap<AddProductRequest, Product>().ForMember(i=> i.UnitPrice, opt => opt.MapFrom(dto => dto.Price));    // UnitPrice alanı için şu opsiyonları kullan -> Product'ın içindeki UnitPrice için dto'daki Price alanını kullan demiş oluyoruz.

            // ---NOT-- GENELLİKLE DTO'DAKİ ALANLA ENTITY İÇİNDEKİ İSİMLERİMİZİ AYNI YAPMAYA ÖZEN GÖSTERİRİZ.

            CreateMap<Product, ListProductResponse>().ReverseMap();
        }
    }
}
