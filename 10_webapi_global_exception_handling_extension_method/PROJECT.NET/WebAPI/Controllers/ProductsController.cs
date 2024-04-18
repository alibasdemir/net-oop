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

        public async Task<List<Product>> GetAll() 
        {
            return await _productService.GetAll();
        }

        [HttpPost]
        public async Task Add([FromBody] Product product)   // async yaptık ve Task yazdık
        {
            // Ürün eklerken bir çok işlem gerçekleştireceğiz. Örneğin:
            // Validation, İş kuralları, Authentication, Veritabanı bağlantısı gibi
            await _productService.Add(product);             // async olduğu için await ekledik
        }

        [HttpGet("Senkron")]
        public string Sync()
        {
            Thread.Sleep(5000);             // 5 saniye beklet. Thread ile çalışan senkron kod bloğumuz thread çalışırken sıraya girer ve thread'in bitmesini bekler. Bu 5 saniyelik bekleme bitmeden diğer hiçbir işlem başlamaz. Örneğin senkron bir işleme ve bu senkron işleme aynı anda get isteği atarsak önce thread işlemi için 5 saniye bekler ve bu işlem bittikten sonra diğer attığımız get işlemi çalışmaya başlar ANCAK ASENKRONDA BU DURUM YOKTUR İŞLEMLER BİRBİRİNDEN BAĞIMSIZ ÇALIŞIR BU YÜZDEN ASENKRON YAPILARI KULLANIRIZ.
            return "Sync endpoint";
        }

        [HttpGet("Asenkron")]
        public async Task<string> Async()   // Asenkron işlemler async olarak belirtilir ve dönüş tipi Task olarak belirtilir.
        {
            Task.Delay(5000);               // asenkron işlemlerde örneğin burayı atla ve alt satıra geç demiş oluyoruz. Yani blokladı ve alt satıra geçti. eğer bu satırın beklenmesini istiyorsan asenkron yapılarda beklenmesini istediğimiz yerin başına await ekleriz. Yani beklediğimiz de bunu aslında senkron gibi çalışacak hale getirmiş oluyoruz:
            // await Task.Delay(5000);      // await ile belirttiğimiz durumlarda ise işlemin bitmesini bekle demiş olduğumuz durumlardır. Yani bu işlemin bitmesini bekle ve bittikten sonra diğer satıra geç demiş oluyoruz.
            return "Async endpoint";
        }
    }
}
