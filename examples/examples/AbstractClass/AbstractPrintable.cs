namespace examples.AbstractClass

// abstract class (soyut sınıf), tamamlanmamış veya kısmen tamamlanmış sınıfları temsil eden bir sınıf türüdür. Abstract class'lar, diğer sınıflar için bir şablon veya temel işlevselliği sağlar ancak kendileri doğrudan örneklenemez. Bunun anlamı, bir abstract class'tan doğrudan bir nesne oluşturamazsınız, ancak bu class'tan türetilen alt sınıfların örneklerini oluşturabilirsiniz.

/*
 
Abstract sınıflar, tek başına bir nesne olarak kullanılamazlar, türetilmiş sınıfların ortak davranışlarını gruplamak için kullanılır.
Abstract sınıflar, içlerinde hem somut (implementasyonu olan) metotlar hem de soyut (implementasyonu olmayan) metotlar bulundurabilir.
Bir sınıf sadece bir abstract sınıftan türetilebilir (tekli kalıtım).  

*/


{
    public abstract class AbstractPrintable
    {
        public abstract void Print(); // Abstract bir metot tanımlanıyor (sadece imza, uygulama yok)
    }

    // Rectangle sınıfı, AbstractPrintable sınıfından türetiliyor
    public class Rectangle2 : AbstractPrintable
    {
        public override void Print()
        {
            Console.WriteLine("Rectangle tipini yazdır");
        }
    }

    // Circle sınıfı, AbstractPrintable sınıfından türetiliyor
    public class Circle2 : AbstractPrintable
    {
        public override void Print()
        {
            Console.WriteLine("Circle tipini yazdır");
        }
    }
}
