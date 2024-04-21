using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Commands.Update
{
    public class UpdateProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
