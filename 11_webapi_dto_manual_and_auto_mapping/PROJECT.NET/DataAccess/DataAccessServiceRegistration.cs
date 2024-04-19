using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    // Servis bağımlılıklarını artık Program.cs içine yazmak yerine her katmanın içinde kendine ait şekilde tanımlama yapıyoruz. Bunun için extension metod kullanıyoruz.
    public static class DataAccessServiceRegistration   // extension metod olduğu için bu bir static class olmalıdır
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)  // bu bağımlılığı Program.cs' de tanımlıyoruz ---> builder.Services.AddDataAccessServices(); ---> Program.cs içine yazdık
        {
            services.AddScoped<IProductRepository, EfProductRepository>();  

            services.AddDbContext<BaseDbContext>();

            return services;
        }
    }
}
