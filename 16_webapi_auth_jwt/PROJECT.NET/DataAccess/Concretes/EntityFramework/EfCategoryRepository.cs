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
    public class EfCategoryRepository : EfRepositoryBase<Category, BaseDbContext>, ICategoryRepository      // ICategoryRepository silmiyoruz çünkü çalışabilecek özel yöntemleri de alması gerekiyor
    {
        public EfCategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
