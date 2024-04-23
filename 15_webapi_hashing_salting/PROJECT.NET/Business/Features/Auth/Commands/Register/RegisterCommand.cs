using AutoMapper;
using Core.Utilities.Hashing;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest // IRequest inheritance veriyoruz. şuanlık bir dönüş tipimiz yok o yüzden dönüş tipi vermedik
    {
        // Kullanıcı kayıt olurken bize vereceği bilgileri buraya yazıyoruz. yani kullanıcıdan isteyeceğimiz alanlar

        public string Email { get; set; }
        public string Password { get; set; }    // BUNU KULLANACI VERECEĞİ İÇİN string yapıyoruz. bu kısımda byte array yapmıyoruz
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand>      // handler ekliyoruz. handler edeceği komutu yazdık ve bu komutun dönüş tipini normalde ikinci argüman olarak ekliyoruz ancak şuanda olmadığı için eklemedik.  
        {
            private readonly IMapper _mapper;   // mapper'ı dependency injection yaptık
            private readonly IUserRepository _userRepository;   // oluşturduğumuz user repository'mizi dependency injection yapıyoruz

            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository)   // ve constructor'ını ekledik
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                // Register komutu trigger olduğunda çalışacak fonksiyon
                
                User user = _mapper.Map<User>(request);     // user'ı mapper kullanarak requestten mapleyerek kullanırız.


                // HASHING VE SALTING İŞLEMLERİNİ HashingHelper.cs İÇİNDE OLUŞTURDUK. Burada kullanıyoruz:
                byte[] passwordHash, passwordSalt;  // iki adet byte array değişkeni oluşturduk

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt); // Kullanıcının verdiği şifreyi passwordHash ve passwordSalt değişkenine out yazarak atayabiliriz. ve altta ki gibi kullanabiliriz: (out ettiğimiz sıra alttakiyle aynı sırada olmalıdır)

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userRepository.AddAsync(user);   // veritabanına user'ı ekliyoruz
            }
        }
    }
}
