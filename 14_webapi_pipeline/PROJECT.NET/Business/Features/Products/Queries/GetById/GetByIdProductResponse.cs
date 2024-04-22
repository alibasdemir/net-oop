using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Queries.GetById
{
    public class GetByIdProductResponse
    {
        // BU KISIMA İSTEK SONRASI KULLANICININ GÖRECEĞİ ALANLAR YAZILIR.
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
