using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        // CQRS-MEDIATR SONRASI SERVİSLERİ ARTIK ANA METOD OLARAK KULLANMAYACAĞIZ - BURAYI ARTIK KOD TEKRARINI ENGELLEMEK İÇİN KULLANACAĞIZ

        Task<Category?> GetByIdAsync(int id);
    }
}
