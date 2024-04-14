using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int ıd, string name, double unitPrice, int stock, int categoryId)
        {
            Id = ıd;
            Name = name;
            UnitPrice = unitPrice;
            Stock = stock;
            CategoryId = categoryId;    // 3- constructor'ı categoryid içerecek şekilde güncelliyoruz
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock {  get; set; }
        public int CategoryId { get; set; }             // 1- Category ile ilişkilendiriyoruz
        public virtual Category Category { get; set; }  // 2- ORM'de ilişkili olan nesne direkt eklenir ve virtual olarak işaretlenir. (Sanal bir alan, tablonun içinde gerçekten bulunmayacak bir alan)

        // NOT: Bu ilişki one to many bir ilişkidir. (bir ürünün bir kategorisi vardır. bir kategorinin birden fazla ürünü vardır)

        // NOT2: Bir ürünün bir kategorisi olduğu için tekil yazılır yani list yazılmaz. 
    }
}

