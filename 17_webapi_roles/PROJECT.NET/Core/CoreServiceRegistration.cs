using Core.Utilities.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, TokenOptions tokenOptions) // tokenOptions parametresi verdik ve bunu Program.cs -> builder.Services.AddCoreServices(); içinde tokenOptions olarak göndereceğiz
        {
            services.AddScoped<ITokenHelper, JwtHelper>(_ => new JwtHelper(tokenOptions));  // jwt'nin üretildiği anı burada ezebiliyoruz. yani biz bunu yazdığımızda .net arkada new'liyor ve hatta .net bu new'leme işlemini manuel yapabilmemizi bile sağlıyor. bunu da parantez içine lambda expression vererek yapabiliyoruz. Ayrıca lambda'da eğer bir parametre yoksa void bir fonksiyon ise kaçış karakteri olan alt çizgiyi ( _ )' yi kullanıyoruz. ve bu bağımlılığı nasıl new'lemek istediğimizi seçiyoruz -> new JwtHelper(tokenOptions) ===> Bu sayede ilgili bağımlılığı ezmiş oluyoruz.

            return services;
        }
    }
}
