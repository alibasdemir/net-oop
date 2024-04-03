using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // api/products diye bir istek gelirse bu alttaki controller devreye girer
    [Route("api/[controller]")]     // bunlar attribute'lardır
    [ApiController]                 // bunlar attribute'lardır (aspect diye de geçer)
    public class ProductsController : ControllerBase    // ControllerBase'den türer.
    {
        [HttpGet]   // Örneğin kullanıcı api/products linkine bir get isteği attığı zaman alttaki metodun çalışması için bu [HttpGet] i buraya ekliyoruz
        public string Hello()
        {
            return "Merhaba";
        }

        [HttpGet("test")]   // Bu da api/products/test isteği attığımızda çalışacak bir get isteği örneğidir.
        public string Test()
        {
            return "Test";
        }

        [HttpGet("name")]
        public string Name(string name) // Parametre ekleyerek kullanıcıdan bilgi alabiliriz. Ve bu aldığımız bilgi URL'den okunur. Örneğin name parametresi ali aldı diyelim, bu durumda /api/products/name?name=ali olacak ve name parametresi URL'den alınarak "Merhaba ali" dönecektir
            // HTTP İSTEĞİNDEN BİRDEN FAZLA VERİ OKUNABİLEN ALANLAR VARDIR: Params, Query String, Body, Headers gibi
        {
            return "Merhaba " + name;
        }

        [HttpGet("name2")]
        public string Name2([FromQuery]string name2) // FromQuery'de aynı işi yapar. URL'den name2 parametresini okur ve onu döner. FromQuery sadece name2 parametresinin URL sorgu dizisinden (query'den) alındığını açıkça belirtir. Yani yukarıda örnek ve bu aynı sonucu verir, dediğimiz gibi FromQuery sadece kodun daha iyi okunmasını sağlar ve bu durumu belirtmeye yarar.
        {
            return "Merhaba " + name2;
        }

        [HttpGet("nameandsurname")]
        public string NameAndSurname([FromQuery]string name3, [FromQuery]string surname)   // 2 parametre verdik. api/products/nameandsurname?name3=ali&surname=veli ile name3 ve surname değerlerini query'den alarak "Merhaba ali veli" döner
        {
            return "Merhaba " + name3 + " " + surname;
        }

        [HttpGet("{username}")] // Verdiğimiz route üzerindeki değeri alır Örneğin /api/Products/ali kısmından ali'yi alır

        public string Username([FromRoute]string username)
        {
            var language = Request.Headers.AcceptLanguage;  // Headers yan bilgileri içerir dedik. burada language kısmı eğer en ise "Your username: username" dönecek. (Accept-Language en göndermemiz gerekiyor). İşte headers bu tarz yan bilgileri içeriyor. Örneğin bir ürün ekliyoruz ve ürün eklendi gibi bir mesaj göndereceğiz, işte bu tarz durumlar yan bilgi olduğu için headers'ın görevidir.
            if (language == "en")
                return "Your username: " + username;
            return "Kullanıcı adınız: " + username; // route üzerindeki değeri alarak ali yazdıysak "Kullanıcı adınız: ali" döner 
        }

        // NOT:
        // Route Parameters, Query String => Get isteklerinde popülerdir.
        // Body => POST, PUT
        // Headers => Yan bilgileri içerir.

        [HttpPost]
        public Product JsonDeneme([FromBody] Product product)   // Producttan örnek olması için aldık ve body json. C# classı yazmamıza rağmen json olarak döner. Yani c# dan json'a veya json'dan c#'a yazma işlemini otomatik yapar
        {
            return product;
        }
    }
}
