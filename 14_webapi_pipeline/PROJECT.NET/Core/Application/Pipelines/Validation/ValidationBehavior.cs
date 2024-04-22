using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Core.Application.Pipelines.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>  // IPipelineBehavior isimli interface'den türetiyoruz. ValidationBehavior'a sen bir request ve bir response alacaksın diyoruz. IPipelineBehavior'a da aynı şekilde dışarıdan aldığımız request ve response'u gönderiyoruz. ve where kısmı ise request her zaman mediatr'dan türeyen bir request olmalıdır şeklinde kıstası vermemiz gerekiyor.
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;      // birden fazla olabileceği için IEnumerable yazdık.. BusinessServiceRegistration'a fluentvalidation.dependencyinjectionextensions sonrası yazdığımız servis sayesinde bu şekilde dependency injection yapabildik. Core paketine FluentValidation paketini kurmayı unutmuyoruz

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            // HER COMMAND ÖNCESİ ÇALIŞACAK KOD
            // FluentValidation

            Console.WriteLine("Validation çalıştı...");

            ValidationContext<object> context = new ValidationContext<object>(request);

            var errors = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .ToList();

            if(errors.Any())
                throw new ValidationException(errors.Select(e => e.ErrorMessage).ToList());

            // ---- NOT ---- ARTIK HİÇBİR KOMUTUN İÇİNDE VALIDATOR'LERİ BUL, ONLARI NEW'LE, SONUCU KONTROL ET GİBİ ÖRNEĞİN; CreateProductCommand içinde yazdığımız validator yapısına ihtiyacımız yok.

            // next ise => kesildiği yerden sonraki işlemleri kontrol ediyor. örneğin validationbehavior ve authbehavior arasında ki iletişim okları next'i temsil ediyor. Yani biz ValidationBehavior'ı yaptık bitirdik ve sıradaki pipeline'a doğru devam etmesini söylememiz gerekiyor. İşte next bu görevi üstlenen alan

            TResponse response = await next();  // kodu devam ettir, oradan gelen cevabı dön
            return response;
        }
    }
}
