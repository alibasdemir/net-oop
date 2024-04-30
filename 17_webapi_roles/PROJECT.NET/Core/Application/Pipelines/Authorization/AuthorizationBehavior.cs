using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    // auth işlemini pipelinedan geçirmek için behavior yapımızı oluşturuyoruz
    public class AuthorizationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> 
        where TRequest : IRequest<TResponse>, ISecuredRequest  // sadece ISecuredRequest ile işaretlenmiş istekleri pipeline üzerinden geçir diyeceğiz ve bunu GetListQuery'e ekleyeceğiz. kullanıcı giriş yapmışsa çalışacak
    {
        private readonly IHttpContextAccessor _httpContextAccessor; // Http bağlayıcı erişimcisi -> .netin bize sağladığı giriş yapıldı mı, token gönderildi mi, gönderildiyse giriş yapmış kullanıcının bilgileri neler, tokenda ne bilgileri var gibi bunun sağladığı arayüzdür. bu arayüzü kullanmak için program.cs'e builder.Services.AddHttpContextAccessor(); ekliyoruz.. ---> bu bağımlılığı behavior ile birlikte kullanıp pipeline kullanıyoruz

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new BusinessException("Giriş yapmadınız");
            }

            if(request.RequiredRoles.Any()) 
            { 
            ICollection<string> userRoles = _httpContextAccessor.HttpContext.User.Claims.Where(i => i.Type == ClaimTypes.Role).Select(i=> i.Value).ToList();    // Value alanlarını select ile seçip liste haline getiriyoruz

            bool hasNoMatchingRole = userRoles.FirstOrDefault(i => i == "Admin" || request.RequiredRoles.Contains(i)).IsNullOrEmpty();     // kullanıcının rollerinde ya admin olacak ya da ilgili istek gerektirdiği rollerden herhangi bir tanesi olacak ve eğer böyle bir durum yoksa:
            if(hasNoMatchingRole)
            {
                throw new BusinessException("Bunu yapmaya yetkiniz yok");
            }   // GetListQuery.cs içine public string[] RequiredRoles => ["Product.Add", "Product.Update"]; ekliyoruz. Yani Product.Add veya Product.Update rolüne sahipse bu komutu çalıştırabilir. Ayrıca bu kodda belirttiğimiz Admin rolüne sahipse.
            }

            TResponse response = await next();
            return response;
        }
    }
}
