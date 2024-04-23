using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware    // middleware olarak kullanacağımız class'ımızı oluşturduk ve bunu Program.cs içinde app.UseMiddleware<ExceptionMiddleware>(); şeklinde tanımlıyoruz. Yani hangi class'ı middleware olacağımızı tanımlamış oluyoruz.
    {
        private readonly RequestDelegate _next;             // 2- bu bir bağımlılıktır. RequestDelegate middleware'ların dikine bölme işleminden sonrasının çalışması için, devam ettirmek için kullanılan request'in kendisidir. Yani request processing'i temsil eden bir task.

        public ExceptionMiddleware(RequestDelegate next)    // 3- constructor
        {
            _next = next;
        }

        // Middleware'ler içerisinde asenkron Task dönüş tipine sahip bir Invoke metoduna ve bu metodun içinde HttpContext'e sahiptir.
        public async Task Invoke(HttpContext context)   // 1- Core katmanında olduğumuz için bu bir web projesi değil bu yüzden HttpContext'i ilk yazışımızda göremiyor. Bu yüzden Microsoft.AspNetCore.Http paketini indirip kuruyoruz. Bu sayede bu core paketi web uygulamalarındaki yapılarla da çalışabilir.
        {
            try
            {
                await _next(context);                   // 4- isteği try catch ile sarmallayıp devam ettirir
            }
            catch(Exception exception) 
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                if(exception is BusinessException)    // Eğer exception BusinessException ise;
                {
                    ProblemDetails problemDetails = new ProblemDetails();
                    problemDetails.Title = "Business Rule Violation";
                    problemDetails.Detail = exception.Message; // veya exception.Message yerine hataları kendimiz de yazabiliriz. Örneğin "Hata";
                    problemDetails.Type = "BusinessException";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));    // JsonSerializer ile Serialize edersek bu bize class'ı string halinde json olarak verir. bu şekilde yazdırabiliriz. serialize etmeden problemDetails yazdırmaya çalışırsak, kızaracak.
                }
                else if(exception is ValidationException)
                {
                    ValidationException validationException = (ValidationException) exception;   // Casting işlemi
                    ValidationProblemDetails validationProblemDetails = new ValidationProblemDetails(validationException.Errors.ToList());

                    await context.Response.WriteAsync(JsonSerializer.Serialize(validationProblemDetails));
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;     // örneğin business exception değilse 500 hatası dönsün
                    await context.Response.WriteAsync("Bilinmedik Hata");
                }

            }
        }
    }
}
