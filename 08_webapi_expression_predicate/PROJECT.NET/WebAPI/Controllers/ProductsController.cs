using Business.Abstracts;
using Business.Concretes;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // api/products diye bir istek gelirse bu alttaki controller devreye girer
    [Route("api/[controller]")]     // bunlar attribute'lardır
    [ApiController]                 // bunlar attribute'lardır (aspect diye de geçer)
    public class ProductsController : ControllerBase    // ControllerBase'den türer.
    {

       // IProductService productService = new ProductManager();  // NEW'LEMEK YANLIŞ BUNUN YERİNE DI YANİ DEPENDENCY INJECTION KULLANIRIZ. 

        IProductService _productService;    // // burada isimlendirme kuralında class içindeki global değişkenler c#'da alt tire ile yazılır
        public ProductsController(IProductService productService)
        {
            _productService=productService;
        }

        [HttpGet]

        public List<Product> GetAll() 
        {
            return _productService.GetAll();
        }

        [HttpPost]
        public void Add([FromBody] Product product)
        {
            // Ürün eklerken bir çok işlem gerçekleştireceğiz. Örneğin:
            // Validation, İş kuralları, Authentication, Veritabanı bağlantısı gibi
            _productService.Add(product);
        }
    }
}
