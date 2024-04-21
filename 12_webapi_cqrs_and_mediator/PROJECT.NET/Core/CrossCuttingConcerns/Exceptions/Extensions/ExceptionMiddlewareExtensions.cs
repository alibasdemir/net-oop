using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionMiddlewareExtensions   // Extension yazılan bir metod static yazılmalıdır.
    {
        public static void ConfigureExceptionMiddlewareExtensions(this IApplicationBuilder app)      // Extent edilecek alan alınır ve başına this yazılır
        {
            app.UseMiddleware<ExceptionMiddleware>();   // Program.cs içinde tanımladığımız bu metodu artık burada kullanabiliriz. Program.cs içinden siliyoruz. Bu metodu kullanma amacımız: ExceptionMiddleware class'ımızı middleware olarak kullanacağımızı tanımlamak.

            // Daha sonra burada oluşturduğumuz ConfigureExceptionMiddlewareExtensions metodumuzu Program.cs içine dahil ediyoruz/yazıyoruz.

            // bu şekilde buraya birden fazla kullanacağımız metod ekleyebiliriz.
        }
    }
}
 