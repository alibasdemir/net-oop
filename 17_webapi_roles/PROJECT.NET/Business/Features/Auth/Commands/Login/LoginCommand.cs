using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Hashing;
using Core.Utilities.JWT;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>   // Loginin artık AccessToken döneceğini söylüyoruz
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper; // kullanıcı giriş yaptığında token üretmek istiyoruz bu yüzden ITokenHelper'ı ekliyoruz. dependency injection
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);
                // User ? user = await _userRepository.GetAsync(i => i.Email == request.Email, include: i => i.Include(i => i.UserOperationClaim).ThenInclude(i=> i.OperationClaim));  // Email'i request.email'ine eşit olan kullanıcı. email kontrolü yapıyoruz. ---- 2 ---> ef ilişkili olunan tüm tabloları performans açısından sorgulamalara direkt olarak dahil etmez bu yüzden dahil olmasını istediğimiz tabloları sorguda görmek için buraya include ile eklememiz gerekir. ve UserOperationClaim içine gittiğimizde de içinde yer alan OperationClaim'i de sorguya dahil etmemiz gerekiyor bu yüzden iç içe kullanabildiğimiz join yapısı kullanmalıyız c# için ise ThenInclude yapısı oluyor. Ama bu noktada yazdığımız joinler daha kullanıcının doğru bir şekilde giriş yapıp yapmadığını bile belirlemeden çalışacağı için bu performans kaybına neden olacak. Bu yüzden bu joinleri tüm kontrollerden sonra (tüm kontrolleri geçmiş kullanıcılar için) yapmak performans açısından en mantıklısı olacaktır. Bu yüzden bu sorguyu burada değil aşağıda tanımlayacağız.

                if (user == null)
                {
                    throw new BusinessException("Giriş başarısız.");
                }   // email yoksa giriş başarısız dönüyoruz

                // kullanıcı null değilse şifre kontrolü yapmamız gerekiyor
                // kayıt olurken oluşturulan salt ve kullanıcının verdiği şifre oluşturulan hash'e eşit mi bunu kontrol edeceğiz.

                // HASHING / SALTING İŞLEMLERİNİ HashingHelper.cs'de yazdık ve kontrolü burada sağlıyoruz:

                bool isPasswordMatch = HashingHelper.VerifPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);   // Kullanıcının verdiği şifre ile veritabanındaki hash'lenmiş password uyuşuyor mu diye SequenceEquel yardımıyla kontrol ediyoruz. Sonuç true veya false döner. bunu isPasswordMatch değişkenine aldık. (request.Password = kullanıcın verdiği şifre, user.PasswordHash = önceden belirlenmiş şifre, user.PasswordSalt = önceden belirlenmiş salt)

                if (!isPasswordMatch)
                {
                    throw new BusinessException("Giriş Başarısız.");
                }   // şifre uyuşmuyorsa giriş başarısız dönüyoruz

                // --- NOT --- => GİRİŞ YAPILIRKEN VERİLEN HATA MESAJLARININ AYNI VERİLMESİ BEST PRACTICE'DIR. BU ÖRNEĞİMİZDE OLDUĞU GİBİ "Giriş Başarısız." ŞEKLİNDE. Çünkü örneğin e-postanın sistemde kayıtlı olup olmadığı konusunda güvenlik zaafiyeti vermek istemeyiz. Bu yüzden hatanın epostanın kayıtlı olduğu mu yoksa şifrenin yanlış olduğundan mı kaynaklı olduğunu net şekilde belirtmeyiz. Bu yüzden genellikle sistemlerde "Eposta veya şifreniz hatalı" şeklinde hata mesajı gösterir. Hangisinin hatalı olduğunu direkt olarak söylemez.

                // KULLANICI ROLLERİNİ SORGULA
                List<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(i => i.UserId == user.Id, include: i => i.Include(i => i.OperationClaim));   // IUserOperationClaimRepository bağımlılığını ekledikten sonra, _userOperationClaimRepository repository'nin GetListAsync metodunun filtresi userId'si userId'sine eşit olanları bul ve bu ara tablonun rol tablosunu devreye al demiş olduk. Bu sayede kullanıcının rolleri bir liste halinde okuyabiliyoruz

                return _tokenHelper.CreateToken(user, userOperationClaims.Select(i=>(Core.Entities.OperationClaim) i.OperationClaim).ToList());     // JwtHelper ve ITokenHelper'da operationClaim'i dışarıdan bilgi olarak gönderiyoruz ve claims içine gönderiyoruz. Ardından burayı bu yaptıklarımıza uygun olarak güncelliyoruz.
            }
        }
    }
}
