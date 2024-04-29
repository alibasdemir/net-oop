using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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
            TResponse response = await next();
            return response;
        }
    }
}
