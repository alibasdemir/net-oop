using Core.DataAccess;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfProductRepository : EfRepositoryBase<Product, BaseDbContext>, IProductRepository     // IProductRepository silmiyoruz çünkü çalışabilecek özel yöntemleri de alması gerekiyor
    {
        public EfProductRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
