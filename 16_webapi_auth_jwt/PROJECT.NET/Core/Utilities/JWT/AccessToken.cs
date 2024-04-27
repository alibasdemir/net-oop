using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class AccessToken    // ilgili komutlarımız, login komutu gibi geriye token döndürmesi gerekiyor bu yüzden AccessToken modelini kullanacağız. Token'ı ve belirlenen süre içisinde geçerliliği yitirecek şeklinde dönüş sağlayacağız ve JwtHelper'da kullanacağız
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
