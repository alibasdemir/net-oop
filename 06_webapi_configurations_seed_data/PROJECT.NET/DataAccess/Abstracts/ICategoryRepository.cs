using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
