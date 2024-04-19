using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Product.Requests
{
    public class AddProductRequest       // ürün eklenirken kullanıcıdan talep edeceğimiz bilgileri, kalıbı tutacak alandır. Kullanıcının yazmasına gerek olmayan örneğin id, addeddatetime gibi alanları içermez
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
