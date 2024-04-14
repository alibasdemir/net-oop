using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category : Entity      // Core katmanındaki Entity'i miras almalıdır. Almazsa EfCategoryRepository kızaracaktır.
    {
        public Category()                       // bir boş constructor ekledik
        {
        }

        public Category(int ıd, string name)     // ve dolu bir constructor ekledik. Constructorlarda hiçbir zaman virtual alanlara yer vermeyiz. Yani parametre olarak virtual alanlar alınmaz. burada örneğin virtual olan product almadık çünkü bu virtual alanlar ilişki sonucu otomatik oluşan alanlardır
        {
            Id = ıd;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set;}  // bir kategorinin birden fazla ürünü olduğu için list şeklinde yazılır ancak best practice olarak List yerine ICollection vermek daha mantıklıdır. Ve virtual olarak işaretlenir
    }
}
