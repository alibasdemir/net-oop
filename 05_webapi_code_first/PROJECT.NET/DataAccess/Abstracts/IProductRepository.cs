using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IProductRepository
    {
        Product GetById(int id);        
        List<Product> GetAll();         
        void Add(Product product);      
        void Update(Product product);   
        void Delete(Product product);
    }
}
