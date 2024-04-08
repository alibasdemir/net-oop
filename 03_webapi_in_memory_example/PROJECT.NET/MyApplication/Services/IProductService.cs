using MyApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    public interface IProductService    // INTERFACE
    {
        // INTERFACE BİZDEN HERHANGİ BİR BODY BEKLEMEZ
        public void AddProduct(Product product);    // SOYUTLAMA. HERHANGİ BİR BODY VERMEDİK. CLASSTA BÖYLE BİR METOD OLUŞTURURSAK BİZDEN BODY BEKLER.
        public void UpdateProduct(Product product); // SOYUTLAMA
    }
}
