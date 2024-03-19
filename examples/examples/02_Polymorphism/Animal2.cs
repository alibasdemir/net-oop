namespace examples._02_Polymorphism

// Polimorfizm, farklı nesnelerin aynı yöntemi çağırmasıyla ilgili bir kavramdır. Bu, farklı türlerdeki nesnelerin aynı şekilde davranabileceği anlamına gelir. C# gibi nesne yönelimli programlama dillerinde, polimorfizmi genellikle kalıtım (inheritance) ve arayüzler (interfaces) kullanarak elde edilir.

    // Inheritance ile polymorphism
{
    public class Animal2
    {
        public virtual void Sound()
        {
            Console.WriteLine("Bilinmeyen bir ses çıkarıldı");
        }
    }

    class Sheep : Animal2
    {
        public override void Sound()
        {
            Console.WriteLine("Meeeğğ Meeeğ");
        }
    }

    class Bird : Animal2
    {
        public override void Sound()
        {
            Console.WriteLine("Cik Cik");
        }
    }

    class Cow : Animal2
    {
        public override void Sound()
        {
            Console.WriteLine("Möööö");
        }
    }

    class Duck : Animal2
    {
        public override void Sound()
        {
            Console.WriteLine("Vak Vak");
        }
    }
}

/*

Bu kod örneğinde polimorfizm, Animal2 sınıfından türetilen alt sınıfların (Sheep, Bird, Cow, Duck) Sound metodu üzerinden gerçekleşir.

Polimorfizmin en belirgin örneği, her alt sınıfın Sound metodunu farklı bir şekilde uygulamasıdır. Örneğin, Sheep sınıfında Sound metodunda "Meeeğğ Meeeğ" yazılırken, Bird sınıfında "Cik Cik", Cow sınıfında "Möööö", ve Duck sınıfında "Vak Vak" yazdırılır.

Bu şekilde, farklı alt sınıflar aynı temel metodu (Sound) aynı şekilde çağırabilir ve her biri kendi özel uygulamasını çalıştırır. Bu, polimorfizmin temel özelliklerinden biridir: farklı nesnelerin aynı metodu farklı şekillerde uygulayabilmesi.

*/