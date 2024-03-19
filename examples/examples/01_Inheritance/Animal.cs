using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace examples._01_Inheritance
{
    public class Animal
    {
        private int _age;           // Animal sınıfının private (özel) erişim belirleyicisine sahip _age isimli bir tamsayı (int) alanı oluşturuyoruz.
        private string _gender;     // Animal sınıfının private (özel) erişim belirleyicisine sahip _gender isimli bir metin (string) alanı oluşturuyoruz.
        public Animal(int age, string gender)   // // Animal sınıfının yapıcı (constructor) metodunu tanımlıyoruz. Bu metod, yaş ve cinsiyet parametreleri alır.
        {
            _age = age;             // _age alanına, metot parametresi olan yaş değerini atıyoruz.
            _gender = gender;       // _gender alanına, metot parametresi olan cinsiyet değerini atıyoruz.
        }
    }

    public class Cat : Animal // Cat adında bir sınıf tanımlıyoruz ve bu sınıf Animal sınıfından miras alıyor.
    {
        public string CatBreed { get; set; } // Kedi türünü temsil eden CatBreed (KediTürü) adında bir otomatik özellik (property) tanımlıyoruz.

        public Cat(int age, string gender, string catBreed) : base(age, gender) // Cat sınıfının yapıcı (constructor) metodunu tanımlıyoruz. Bu metod, yaş, cinsiyet ve kedi türü parametrelerini alır.
                                                                                // **** NOT: **** : base ifadesi parametreli bir yapıcı metod tanımlamışsak kullanılır. parametresiz ise kullanmak zorunda değiliz.
        {
            CatBreed = catBreed; // CatBreed özelliğine, metot parametresi olan kedi türü değerini atıyoruz.
            Console.WriteLine($"{age}, {gender}, {catBreed}"); // Konsola, kedi objesi oluşturulduğunda yaş, cinsiyet ve kedi türü bilgilerini yazdırıyoruz.
        }
    }

    public class Dog : Animal // Dog adında bir sınıf tanımlıyoruz ve bu sınıf Animal sınıfından kalıtım alıyor.
    {
        private string _dogStructure; // Köpek yapısını temsil eden _dogStructure (KöpekYapısı) adında bir metin (string) alanı oluşturuyoruz.

        public Dog(int age, string gender, string dogStructure) : base(age, gender) // Dog sınıfının yapıcı (constructor) metodunu tanımlıyoruz. Bu metod, yaş, cinsiyet ve köpek yapısı parametrelerini alır.
        {
            _dogStructure = dogStructure; // _dogStructure alanına, metot parametresi olan köpek yapısı değerini atıyoruz.

            Console.WriteLine($"{age}, {gender}, {dogStructure}"); // Konsola, köpek objesi oluşturulduğunda yaş, cinsiyet ve köpek yapısı bilgilerini yazdırıyoruz.
        }

        public void DisplayDogDetails()
        {
            Console.WriteLine($"Dog Structure: {_dogStructure}");   // Animal'da private oluşturduğumuz _age ve _gender'a buradan ulaşamayız
        }
    }
}

// **** NOT: ***** Eğer Animal sınıfında sadece parametreli bir yapıcı metod tanımlamışsanız ve parametresiz bir yapıcı metod tanımlamamışsanız, : base(name, age) ifadesini kullanmak zorunda değilsiniz. Çünkü Dog sınıfının yapıcı metodu çağrıldığında, otomatik olarak Animal sınıfının parametreli yapıcı metodunun çağrılması gerekecektir. Bu durumda, Dog sınıfının yapıcı metodu otomatik olarak üst sınıfın yapıcı metoduna gerekli parametreleri iletecektir.

// Kısaca; Eğer miras alınan constructor parametreli ise base kullanmak zorunlu. kullanmazsak hata verir. Eğer miras alınan constructor parametresiz ise base kullanmak zorunlu değil ama kullanılırsa da hata vermez.