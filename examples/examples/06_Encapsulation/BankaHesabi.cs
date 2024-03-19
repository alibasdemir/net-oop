using examples._01_Inheritance;
using examples._02_Polymorphism;

namespace examples._06_Encapsulation

// Encapsulation (Kapsülleme), nesne yönelimli programlamada bir programın işlevselliğini ve verilerini bir arada tutma ve birimlerin dışarıdan erişilemez olmasını sağlama sürecidir. Bu, bir nesnenin iç yapısını gizlemek ve sadece belirli bir arayüz aracılığıyla erişilebilir hale getirmek anlamına gelir.

// Örnek olarak, bir banka hesabı düşünelim.Banka hesabı, bakiye gibi özelliklere ve para yatırma, para çekme gibi işlemlere sahip olabilir. Ancak, bu özelliklere ve işlemlere doğrudan erişim izni vermek, hesabın güvenliğini tehlikeye atabilir. Bu yüzden, banka hesabının iç yapısını gizleyerek, sadece belirli işlevler aracılığıyla bu özelliklere erişim sağlanabilir.

{
    public class BankaHesabi
    {
        private string _hesapSahibi; // Banka hesabının sahibinin adını tutan private bir alan (_hesapSahibi)
        private double _bakiye;      // Banka hesabının bakiyesini tutan private bir alan (_bakiye)


        public BankaHesabi(string sahip, double miktar)    // BankaHesabi sınıfının constructor'ı
        {
            _hesapSahibi = sahip;   // hesapSahibi alanını parametre olarak gelen sahip değeriyle ayarlar
            _bakiye = miktar;      // bakiye alanını parametre olarak gelen miktar değeriyle ayarlar
        }


        // Bakiye özelliği. Banka hesabının bakiyesine sadece okuma (get) erişimi sağlar.
        public double GetBakiye()  // (getter)
        {
            return _bakiye; // _bakiye alanını döndürür
        }

        // ParaYatir metodu. Belirtilen miktar kadar para yatırır.
        public void SetParaYatir(double miktar)     // (setter)
        {
            if (miktar > 0)
            {
                _bakiye += miktar; // Bakiyeye yatırılan miktarı ekler
                Console.WriteLine($"{_hesapSahibi} hesabına {miktar} TL yatırıldı. Yeni bakiye: {_bakiye} TL");
            }
            else
            {
                Console.WriteLine("Geçersiz işlem: Yatırılacak miktar sıfırdan büyük olmalıdır.");
            }
        }

        // ParaCek metodu. Belirtilen miktar kadar para çeker.
        public void SetParaCek(double miktar)   // (setter)
        {
            if (miktar > 0 && miktar <= _bakiye)
            {
                _bakiye -= miktar; // Bakiyeden çekilen miktarı düşer
                Console.WriteLine($"{_hesapSahibi} hesabından {miktar} TL çekildi. Yeni bakiye: {_bakiye} TL");

            }
            else
            {
                Console.WriteLine("Geçersiz işlem: Çekilecek miktar sıfırdan büyük ve hesap bakiyesinden küçük olmalıdır.");
            }
        }
    }
}

// Bu örnekte, BankaHesabi sınıfı, encapsulation ilkesini uygular. hesapSahibi ve bakiye gibi özellikler private olarak tanımlanır ve sadece bu sınıfın içinden erişilebilirler. Dışarıdan bu özelliklere doğrudan erişim engellenir ve Bakiye özelliği aracılığıyla sadece bakiye bilgisine erişilebilir. ParaYatir ve ParaCek metodları aracılığıyla ise sadece belirli kontroller yapılarak para yatırma ve çekme işlemleri gerçekleştirilebilir. Bu sayede, hesap bilgilerinin güvenliği sağlanır ve dışarıdan doğrudan değiştirilmesi engellenir. Bu da encapsulation'ın sağladığı bir güvenlik ve esneklik avantajıdır.