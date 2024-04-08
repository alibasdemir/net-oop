using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Entities
{
    // ENTITIES KLASÖRÜ VARLIKLARI TUTAR. PRODUCT SINIFINI BURADA TUTAR VE İÇERİSİNDE PROPERTY, FIELD'LAR YER ALIR
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }
}
