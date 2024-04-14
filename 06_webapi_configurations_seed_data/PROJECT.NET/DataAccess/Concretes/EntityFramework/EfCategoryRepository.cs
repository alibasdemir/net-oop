using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCategoryRepository : ICategoryRepository
    {
        public void Add(Category category)
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            } 
        }

        public void Delete(Category category)    // INMEMORY'DE SİLME İŞLEMLERİ FARKLI REFERANS İŞLEMLERİ GEREKTİREBİLİRDİ. ENTITYFRAMEWORK İÇİN BU ŞEKİLDE Delete işlemlerini gerçekleştiriyoruz
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            using (BaseDbContext context = new())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetById(int id)
        {
            using (BaseDbContext context = new())
            {
                return context.Categories.FirstOrDefault(c => c.Id == id);
            }
        }

        public void Update(Category category)
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Update(category);
                context.SaveChanges();
            }
        }
    }
}
