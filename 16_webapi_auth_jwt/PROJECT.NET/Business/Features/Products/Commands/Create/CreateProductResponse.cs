using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Commands.Create
{
    public class CreateProductResponse      // CreateProductCommand için bir geri dönüş değeri ekledik. Yani ekleme işlemi yaptıktan sonra geri dönülecek alanları belirledik.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
