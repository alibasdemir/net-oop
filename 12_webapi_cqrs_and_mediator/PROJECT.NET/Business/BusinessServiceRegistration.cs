using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    // Servis bağımlılıklarını artık Program.cs içine yazmak yerine her katmanın içinde kendine ait şekilde tanımlama yapıyoruz. Bunun için extension metod kullanıyoruz.
    public static class BusinessServiceRegistration     // extension metod olduğu için bu bir static class olmalıdır
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)  // bu bağımlılığı Program.cs' de tanımlıyoruz ---> builder.Services.AddBusinessServices(); ---> Program.cs içine yazdık
        {

            services.AddMediatR(configuration => {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });  // mediatr ekledik ve assebmly'e ihtiyaç duyduğu için configuration içinde assembly ekledik


            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryService, CategoryManager>();    // category için yeni bir bağımlılık ekledik ve bu katmanda tanımladık

            services.AddAutoMapper(Assembly.GetExecutingAssembly());   // AutoMapper kütüphanesini kurduktan sonra automapper metodunu buraya ekliyoruz. Automapper bizden assembly bekler. Nedeni ise bizim entitylerimiz ile dtolarımız arasında bir mapleme yapıcak bu yüzden. Assembly'i Assembly.GetExecutingAssembly() yazarak veriyoruz
                                                                                             // Assembly ===>>> uygulamamızın veya kütüphanemizin derlenmiş kodunu ve bu kodun çalıştırılması için gerekli olan bileşenleri içeren yapıdır.



            return services;
        }
    }
}
