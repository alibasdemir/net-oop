namespace examples._02_Polymorphism

// Interface (Arayüz), bir sınıfın veya bir nesnenin belirli davranışları sağlamak için kullanılan bir yapıdır. Interface'ler, bir veya daha fazla metodu ve/veya özelliği tanımlar, ancak bunların uygulanmasını içermez. Bunun yerine, interface'leri uygulayan sınıflar bu metodları ve özellikleri kendi içerisinde implemente eder.

// Interface'lerde yöntemlerin imzası (signature) belirtilir, ancak gerçek uygulama (implementation) içerisine herhangi bir kod eklenmez. Yani, bir interface içinde tanımlanan yöntemlerin gövdeleri (implementations) olmaz.

{
    public interface IPass      // interface'ler interface keyword'ü ile tanımlanır ve başında I yazılır.
    {
        void Scan();    // Scan metodumuzu oluşturduk ve gördüğümüz gibi herhangi bir gövdesi bulunmuyor.
    }

    class StudentPass : IPass
    {
        public void Scan()  // IPass interface'inin gerektirdiği şekilde Scan metodu uygulanır.
        {
            Console.WriteLine("Öğrenci kartı okutuldu.");
        }
    }

    class StaffPass : IPass
    {
        public void Scan()
        {
            Console.WriteLine("Personel kartı okutuldu.");
        }
    }

    class VisitorPass : IPass
    {
        public void Scan()
        {
            Console.WriteLine("Ziyaretçi kartı okutuldu.");
        }
    }
}

/*

Bu örnekte, IPass adında bir interface oluşturduk. Bu interface, farklı kart türlerinin (öğrenci kartı, personel kartı, ziyaretçi kartı vb.) sahip olması gereken Scan adında bir metod tanımlar. Her kart türü, kendi özgün davranışını bu Scan metodunda sergiler.

Interface'ler, birden fazla sınıfın aynı davranışı sağlamasını sağlar, bu da kodun daha modüler ve esnek olmasını sağlar. Bu örnekte, farklı kart türlerinin aynı interface'i uygulaması sayesinde, bu kartların hepsi aynı metodu çağırarak farklı davranışlar sergileyebilir.

public class tanımı burada kullanılmadı çünkü IPass, StudentPass, StaffPass ve VisitorPass sınıfları interface'leri temsil ediyor. Interface'lerin tanımlanmasında public anahtar kelimesine gerek yoktur, çünkü interface'ler zaten herkesin erişimine açıktır. Sınıflar interface'leri uyguladığında, bu sınıfların erişim belirleyicisi olan public kullanılır.

*/