using Core.Entities;
using Core.Utilities.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtHelper : ITokenHelper
    {
        /*
        private readonly IConfiguration _configuration;     // ürettiğimiz tokenla doğruladığımız tokenın aynı özellikleri paylaşması gerekiyor. bu yüzden bizim gidip burada appsettings.Development.js dosyasını okuyabilmemiz lazım. Bu dosyayı okuyabilmemiz için bağımlılık olarak IConfiguration bağımlılığına ihtiyacımız vardır. Bu bağımlılığı kullanıp entegre ediyoruz ve constructor'ını oluşturuyoruz.
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        */

        // Diğer yöntem ise IConfiguration okumak yerine TokenOptions dosyamızı okumaktır:

        private readonly TokenOptions tokenOptions;

        public JwtHelper(TokenOptions tokenOptions)
        {
            this.tokenOptions = tokenOptions;
        }

        public AccessToken CreateToken(BaseUser user)     // jwt üretmek için metod yazıyoruz. ama jwt üretmek için user'a ihtiyacımız var ancak core paketi diğer paketlere bağımlı olamaz ve olmamalı. Bu yüzden daha önceden Entites katmanında tanımladığımız User.cs Entites katmanı yerine Core katmanında tanımlanmalıdır, bu yüzden core katmanında Entites klasörü açıp BaseUser.cs oluşturuyoruz. Ve user'a daha sonra özellik eklemek istiyorsak core paketinden extend edip üzerine istediğimiz alanı ekleyebiliriz. Entites içindeki User.cs artık BaseUser'ı miras olacak alacak.
        {
            // İlgili özellikleri oku ve token'ı oluştur:
            DateTime expirationTime = DateTime.Now.AddMinutes(tokenOptions.ExpirationTime);
            SecurityKey key = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); // giriş bilgileri olarak düşünebiliriz

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,       
                audience: tokenOptions.Audience,
                claims: null,
                notBefore: DateTime.Now,
                expires: expirationTime,
                signingCredentials: signingCredentials
                );  // JWT ÜRETİYORUZ

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            string jwtToken = jwtSecurityTokenHandler.WriteToken(jwt);    // yukarıdaki token'ın tüm özelliklerini içeren alanları string'e çevirerek jwtToken değişkenine atıyoruz.

            return new AccessToken() { Token = jwtToken, ExpirationTime = expirationTime };
        }
    }
}
