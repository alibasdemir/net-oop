using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        // CQRS-MEDIATR SONRASI MANAGER'LARI ARTIK ANA METOD OLARAK KULLANMAYACAĞIZ - BURAYI ARTIK KOD TEKRARINI ENGELLEMEK İÇİN KULLANACAĞIZ
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            Category? category = await _categoryRepository.GetAsync(i => i.Id == id);
            return category;
        }
    }
}
