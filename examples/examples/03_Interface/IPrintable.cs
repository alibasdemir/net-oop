namespace examples._03_Interface

// 02_Polymorphism Pass.cs'de interface'i tanımladığım için bu kısımda çok uzun tanımlama yapmayacağım.

/*

Interface'ler, birden fazla sınıf tarafından uygulanabilir.
Bir sınıf birden fazla interface'i uygulayabilir.
Interface'ler, sadece metot imzalarını belirtir, dolayısıyla implementasyonları yoktur.
Interface'ler, çoklu kalıtımı destekler.

 */

{
    // IPrintable interface'i tanımlanıyor
    public interface IPrintable
    {
        void Print(); // Metod imzası tanımlanıyor
    }

    // Rectangle sınıfı, IPrintable interface'ini uyguluyor
    public class Rectangle : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Dikdörtgen tipini yazdır");
        }
    }

    // Circle sınıfı, IPrintable interface'ini uyguluyor
    public class Circle : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Çember tipini yazdır");
        }
    }

}
