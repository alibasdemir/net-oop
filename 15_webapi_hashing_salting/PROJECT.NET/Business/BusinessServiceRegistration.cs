using Business.Abstracts;
using Business.Concretes;
using Core.Application.Pipelines.Validation;
using Core.Application.Pipelines.Logging;
using FluentValidation;
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
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // mediatr ekledik ve assebmly'e ihtiyaç duyduğu için configuration içinde assembly ekledik
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));  // SIRALAMA ÖNEMLİ LOGLAMA Validasyondan önce çalışmalıki validasyon hatası alsak bile loglama çalışsın.
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));    // Kullanacağımız behavior'ı ekledik. ve bizden ValidationBehavior bir request ve bir response istiyor, biz bunu kıstasa uyan tüm tipler için uygulamak istiyorsak <,> arasına virgül koyarız. Yani typeof dediğimiz için bu kıstasa uyan tüm tipleri kabul et demiş oluyoruz
            });  


            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryService, CategoryManager>();    // category için yeni bir bağımlılık ekledik ve bu katmanda tanımladık

            services.AddAutoMapper(Assembly.GetExecutingAssembly());   // AutoMapper kütüphanesini kurduktan sonra automapper metodunu buraya ekliyoruz. Automapper bizden assembly bekler. Nedeni ise bizim entitylerimiz ile dtolarımız arasında bir mapleme yapıcak bu yüzden. Assembly'i Assembly.GetExecutingAssembly() yazarak veriyoruz
                                                                                             // Assembly ===>>> uygulamamızın veya kütüphanemizin derlenmiş kodunu ve bu kodun çalıştırılması için gerekli olan bileşenleri içeren yapıdır.

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());    // Business katmanına FluentValidation.DependencyInjectionExtensions paketini kuruyoruz ve artık validasyonları örneğin CreateProductCommand içinde new'lediğimiz gibi new'lemeye ihtiyacımız kalmadan dependency injection yapabiliriz. Yani ne kadar validasyon varsa hepsini tara ve bunu servislerin içine ekle demiş oluyoruz. Bu tek satır sayesinde artık tüm validasyonlar sistem içinde tanınabilir halde

            return services;
        }
    }
}
