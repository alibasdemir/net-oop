using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            using(BaseDbContext context = new())    // using bloğu => içinde new'lenen bir yapının ilgili blok bittikten sonra dispose edilmesidir. Yani db işlemi bittikten sonra ilgili instance'ın hafızada tutulmasını istemeyiz. Bu yüzden using bloğu kullanırız.
            {
                context.Products.Add(product);
                context.SaveChanges();
            }   // Dispose => ilgili class'ın instance'ının carbage collector tarafından toplanarak yok edilmesi işlemidir.
        }

        public void Delete(Product product)
        {
            using (BaseDbContext context = new())
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            using (BaseDbContext context = new())
            {
                return context.Products.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (BaseDbContext context = new())
            {
                return context.Products.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Update(Product product)
        {
            using (BaseDbContext context = new())
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
        }
    }
}
