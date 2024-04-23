using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Hashing
{
    public static class HashingHelper     // Hashing işlemleri de aynı KDV işlemleri gibi instance oluşturmasına gerek olmayan yapılar olduğu için static class olarak oluştururuz.
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)     // şifre hash'i oluşturan ve bunu geriye dönen yapı. --> (Kullanıcıdan aldığımız şifreyi salt ve hash'e ayırarak geri döndüreceğiz). string password = kullanıcıdan aldığımız şifre. out = bunlar(passwordHash ve passwordSalt) dönüş değeri olduğu için out kullanıyoruz
        {
            using HMACSHA512 hmac = new();  // hashleme ve saltlama yaparken bir HMAC algoritması (hashing algoritması) kullanıyoruz. burada SHA512 kullandık ve bu maliyetli bir alan olduğu için bunu using bloğunda yapıyoruz (kullanım bittiği anda bu değişkeni hafızadan silmesi için)

            passwordSalt = hmac.Key;       // salt'ı biz oluşturacağımız için hmacde oluşturulan rastgele key alanını veriyoruz ve salt'ı oluşturuyoruz
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));       // kullanıcının verdiği şifreyi (bu şifreyi password olarak alıyoruz oluşturduğumuz salt ile birleştiriyoruz ve UTF8 yani byte formatında hashleyerek passwordHash değişkenine gönderiyoruz. Bunu da Encoding paketi sayesinde ComputeHash(Encoding.UTF8.GetBytes içine değeri yazarak döndürebiliyoruz). 
        }

        public static bool VerifPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)      // verilen şifreyle şifrenin doğru olup olmadığını verified eden yapı. --> Kullanıcıdan aldığımız şifreyi yazıyoruz (string password), daha önce hashlediğimiz ve saltladığımız verileri yazıyoruz (passwordHash, passwordSalt -> bunlar dönmeyeceği için out yazmıyoruz)
        {
            using HMACSHA512 hmac = new(passwordSalt); // daha önce oluşturulan salt'ı alıyoruz (kullanıcı şifre oluştururken oluşturulmuş salt) ----- hashleme ve saltlama yaparken bir HMAC algoritması (hashing algoritması) kullanıyoruz. burada SHA512 kullandık ve bu maliyetli bir alan olduğu için bunu using bloğunda yapıyoruz (kullanım bittiği anda bu değişkeni hafızadan silmesi için)

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));   // kullanıcının verdiği şifreyi hashliyoruz daha önceden belirlenmiş salt ile birlikte. (belirlenmiş salt'u yukarıda hmac değişkenine aldık ve onu kullandık burda) 

            return computedHash.SequenceEqual(passwordHash);   // Kullanıcının verdiği şifre ile veritabanındaki hash'lenmiş password uyuşuyor mu diye SequenceEquel yardımıyla kontrol ediyoruz. Sonuç true veya false döner. Ayrıca VerifPasswordHash metodumuzu zaten bool olarak ayarlamıştık
        }
    }
}
