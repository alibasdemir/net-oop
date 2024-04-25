using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ILoggableRequest   // ILoggableRequest EKLEDİK YANİ ARTIK SADECE ILoggableRequest ALMIŞ KOMUT/QUERY'LER LOGLANACAK. ÖRNEĞİN CreateProductCommand'a bu ILoggableRequest ekliyoruz ve bu sayede sadece CreateProductCommand'da yani ürün eklerken loglama çalışacak hale gelmiş olacak ve diğer komut/query'lerde loglama çalışmayacak.
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Loglama çalıştı...");
            return await next();
        }
    }
}
