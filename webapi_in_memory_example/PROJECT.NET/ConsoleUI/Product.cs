using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    // **** ERİŞİM BELİRTECİ ( ACCESS MODIFIERS ) ****
    // PUBLIC  --> TÜM DIŞ DÜNYAYA AÇIK
    // PRIVATE --> İLGİLİ NESNEYE ÖZEL (DIŞARIDAN ERİŞİLMESİNİ İSTEMİYORSAK PRIVATE KULLANIRIZ)
    public class Product
    {
        // CONSTRUCTOR / CTOR
        // GERİ DÖNÜŞ TİPİ OLMAYAN, NESNE İSMİYLE AYNI OLAN YAPIDIR.
        // EĞER İLGİLİ CLASS HİÇBİR CTOR TANIMI İÇERMİYORSA BOŞ PARAMETRELİ CTOR DEFAULT OLARAK  EKLENİR.

        public Product()    // CONSTRUCTOR... ( EĞER BUNU TANIMLAMASAYDIK OTOMATİK OLARAK BOŞ PARAMETRELİ BİR CTOR ZATEN DEFAULT OLARAK EKLENECEKTİ )
        {
            Console.WriteLine("CONSTRUCTOR OLUŞTURULDU");
        }

        public Product(int id, string name)    // BİRDEN FAZLA CTOR TANIMLAYABİLİRİZ.
        {
           Id = id;             // PROPERTY'LERİ SET ETMEK İÇİN KULLANIRIZ
           Name = name;

            // BU SAYEDE Product.cs' de "Product product1 = new Product(1, "Elma");" kullanım sağlayabiliriz. EĞER property'leri set etmeden kullanırsak argüman versek bile örneğin name yazdırmak istediğimizde boş döner. ama set edip yazarsak tanımladığımız elmayı yazdırır
        }

        public int Id { get; set; }     // FIELD
        public string Name { get; set; }

    }
}
