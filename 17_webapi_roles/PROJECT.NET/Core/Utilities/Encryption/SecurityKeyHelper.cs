using Core.Utilities.JWT;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Encryption
{
    public static class SecurityKeyHelper       // JwtHelper.cs ve Program.cs içinde SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)); bunu ayrı yerlerde toplam iki defa new'liyoruz. Özelliği async yapmak istersek iki yerde de değiştirmek zorunda kalacağız. Yani aslında kendimizi tekrarlamış olduk. Bu yüzden burda tanımlayıp iki yerde de buradan alıp kullanacağız. Bu sayede burada yaptığımız değişiklik iki yerede uygulanacak.
    {
        public static SecurityKey CreateSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }   // artık bunu iki yerde de çağırıp kullanabiliriz.
    }
}
