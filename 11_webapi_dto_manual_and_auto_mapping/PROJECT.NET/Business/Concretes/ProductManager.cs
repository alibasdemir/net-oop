using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService   // Soyut sınıf olan IProductService(interface)'in karşılığı olan somut sınıf ProductManager oluşturulur ve bu sınıf IProductService'den kalıtım alınır. Implemente ettikten sonra metodlar yazılır
    {

        private readonly IProductRepository _productRepository;      // burada isimlendirme kuralında class içindeki global değişkenler c#'da alt tire ile yazılır ---- PRIVATE READYONLY YAZMAK BEST PRACTICE'DİR. EKLEMEYİ UNUTMAYALIM.

        private readonly IMapper _mapper;     // automapper kullanmak için bağımlılığı ekliyoruz ve bu bağımlılığı ekledikten sonra bunu constructor'a eklemeyi unutmuyoruz. (soldaki ampüle tıkla + Add parameters to yazana tıkla). Sisteme eklemek için Program.cs içine builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); ekliyoruz. ---- ---- PRIVATE READYONLY YAZMAK BEST PRACTICE'DİR. EKLEMEYİ UNUTMAYALIM.

        // DEPENDENCY INJECTION YAPARKEN HER ZAMAN AKLIMIZA ŞU SORU GELMELİ: BU SERVİS, SERVİSLER ARASINA EKLENDİ Mİ?

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(AddProductRequest dto)  // async olduğu için Task yaptık ---> ARTIK KULLANICADAN İSTEYECEĞİMİZ BİLGİLERİ İÇEREN DTO'yu yazdık "AddProductRequest"
        {
            // ÜRÜN FİYATI 0'DAN KÜÇÜK OLAMAZ
            if(dto.UnitPrice < 0)
            {
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz");
            }

            // AYNI İSİMDE 2.ÜRÜN EKLENEMEZ
            Product? productWithSameName = await _productRepository.GetAsync(p=> p.Name == dto.Name);
            if(productWithSameName is not null)
            {
                throw new System.Exception("Aynı isimde 2. ürün eklenemez");
            }

            /*
            // MAPPING(MANUAL)
            Product product = new();    // dto eklediğimiz için Product'a dto'dan gelen tüm alanları transfer ediyoruz ---> bunun adı mapping(manual).
            product.Name = dto.Name;
            product.Stock = dto.Stock;
            product.UnitPrice = dto.UnitPrice;
            product.CategoryId = dto.CategoryId;
            */

            // AUTO MAPPING(AUTO MAPPER)
            Product product = _mapper.Map<Product>(dto);    // maplemek istediğimiz tür (Product) ve verilerin transfer edileceği kaynağı (dto) yazıyoruz.

            // ---NOT--- Product.cs ve AddProductRequest.cs alanları içindeki isimler aynıysa oto maplenir. Ancak isimlerin farklı olduğu durumda iki alan arası mapleme yapmak istiyorsak özel konfigürasyonlar oluşturmamız gerekir. Örnek ProductMappingProfiles.cs içinde yorum satırında verildi.

            await _productRepository.AddAsync(product);
        }

        public void Delete(int id)
        {
            Product? productToDelete = _productRepository.Get(p=>p.Id == id);
            throw new NotImplementedException();
        }

        public async Task<List<ListProductResponse>> GetAll()        // DTO --->> Ürün listelenirken Product yerine ListProductResponse yazdık
        {
            List<Product> products = await _productRepository.GetListAsync();       // ÜRÜN LİSTESİ

            // 1. YOL --- MANUAL MAPPING
            //List<ListProductResponse> response = new List<ListProductResponse>();     // DTO LİSTESİ

            //foreach(Product product in products)
            //{
            //    ListProductResponse dto = new();
            //    dto.Name = product.Name;
            //    dto.UnitPrice = product.UnitPrice;
            //    dto.Id = product.Id;
            //}

            /*
            // 2. YOL --- MANUAL MAPPING
            List<ListProductResponse> response = products.Select(p => new ListProductResponse()
            {
                Id = p.Id,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
            }).ToList();
            
            return response;
            */


            // AUTO MAPPING(AUTO MAPPER)

            List<ListProductResponse> response = _mapper.Map<List<ListProductResponse>>(products);

            return response;
            
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
