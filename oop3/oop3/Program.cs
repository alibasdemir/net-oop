
// CLASS - CONSTRUCTOR - INSTANCE - INHERITANCE KAVRAMLARI

// NOT: Class'ların içinde operasyon ve özellik tutulabilir. Aşağıda ki örnekte yer alan Calculate ve Save classlarında operasyon tuttuk, Customer classında ise özellik tuttuk.

// ÇOK ÖNEMLİ NOT: Kodlarımız SOLID'e uygun olmalıdır. SOLID'in açıklaması en altta yer almaktadır.

class Program
{
    static void Main(string[] args)
    {
        CreditManager creditManager = new CreditManager();
        creditManager.Calculate();      // istediğimiz kadar çağırabilmemizi sağlar. altta yazdığımız kodları tekrar tekrar yazmamıza gerek kalmaz. Yani 1 defa kodu yaz istediğin yerden çağır
        creditManager.Calculate();
        creditManager.Save();

        Customer customer = new Customer();     // instance oluşturmak (örneğini oluşturmak)
        customer.Id = 1;
        customer.Identity = "12312312312";
        customer.City = "Deneme";

        CustomerManager customerManager = new CustomerManager(customer);
        customerManager.Save();
        customerManager.Delete();

        Company company = new Company();
        company.Id = 2;
        company.TaxNumber = "99999";        // sadece company'e özel
        company.CompanyName = "Company";    // sadece company'e özel
        company.Identity = "12312";
        company.City = "Company City";

        CustomerManager customerManager2 = new CustomerManager(new Company());


        Person person = new Person();
        person.Age = "20";                  // sadece person'a özel
        person.Id = 3;
        person.FirstName = "Person";        // sadece person'a özel
        person.LastName = "Person1";        // sadece person'a özel
        person.Identity = "534543";
        person.City = "Person City";

        CustomerManager customerManager3 = new CustomerManager(new Person());

        Customer c1 = new Customer();   // burada ise Customer c1 ===> Customer'ın heap'de oluşan referans numarasını tutuyor
        Customer c2 = new Person();     // burada ise Customer c2 ===> Person'ın heap'de oluşan referans numarasını tutuyor
        Customer c3 = new Company();    // burada ise Customer c3 ===> Company'nin heap'de oluşan referans numarasını tutuyor

        Console.ReadLine();

    }
}

class CreditManager
{
    public void Calculate()
    {
        //
        //
        //  hesaplamayla alakalı kodlar burada yer alır.
        //
        //
        Console.WriteLine("Hesaplandı");
    }

    public void Save()
    {
        //
        //
        //  kredinin verilmesiyle alakalı kodlar burada yer alır.
        //
        //
        Console.WriteLine("Kredi Verildi");
    }
}

class Customer
{
    public Customer()   // BU YAPIYA CONSTRUCTOR DENİR. Constructor'lar Class'ın ismiyle yazılır.
    {
        Console.WriteLine("müşteri nesnesi başlatıldı");
    }
    public int Id { get; set; }     // c# da bu yapıya property denir. Yani burada ki Id'yi hem yazabiliriz hem okuyabiliriz demek oluyor. Yani Customer'ın id, firstname,lastname ve identity'sini yazabiliriz ve okuyabiliriz.
    public string Identity { get; set; }
    public string City { get; set; }

}

class Company : Customer     // Inheritance (Miras) Yani Company Customer'a ait olan herşeyi miras alır (Id, Identity, City gibi Customer'da yer alan tüm herşeyi miras alır) Company'nin altında oluşturduklarımız ise tamamen Company'e ait olacak.
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
}

class Person : Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Age { get; set; }
}
class CustomerManager
{
    private Customer _customer;
    public CustomerManager(Customer customer)    // constructor'ımıza parametre geçtik
    {
        _customer = customer;
    }
    public void Save()
    {
        Console.WriteLine("Müşteri Kaydedildi: " + _customer.Id);
    }
    public void Delete()
    {
        Console.WriteLine("Müşteri Silindi: " + _customer.Id);
    }
}


/*
 SOLID, yazılım tasarım prensiplerinin bir kısaltmasıdır ve genellikle nesne yönelimli programlama (OOP) ve yazılım tasarımıyla ilgili olarak kullanılır. SOLID, yazılım geliştirme sürecinde daha temiz, esnek ve sürdürülebilir kodlar oluşturmak için rehberlik sağlayan beş temel prensipten oluşur:

S: Tek Sorumluluk İlkesi (Single Responsibility Principle - SRP): Bir sınıfın yalnızca bir sorumluluğu olmalıdır. Sınıfların birbiriyle sıkı bir şekilde bağlı olması yerine, her biri kendi görevlerini tek bir işlevsel alanla sınırlamalıdır.

O: Açık/Kapalı İlkesi (Open/Closed Principle - OCP): Bir sınıf, genişletilebilir olmalı ancak değiştirilemez olmalıdır. Yeni işlevselliği eklemek veya mevcut davranışı değiştirmek için var olan kodu değiştirmek yerine, kodu genişletmek için tasarlanmalıdır.

L: Liskov Değişim İlkesi (Liskov Substitution Principle - LSP): Alt sınıflar, üst sınıfların yerine geçebilmelidir. Yani, bir alt sınıf, üst sınıfın sahip olduğu tüm davranışları sergilemeli ve kullanıldığı herhangi bir yerde üst sınıfın yerine geçebilmelidir.

I: Arayüz Ayırma İlkesi (Interface Segregation Principle - ISP): Bir arayüz, mümkün olduğunca spesifik olmalıdır. Bir sınıf, ihtiyacı olmayan yöntemleri uygulamak zorunda kalmamalıdır. Bunun yerine, birden çok spesifik arayüz kullanarak bir sınıfın ihtiyaçlarını karşılamak daha iyidir.

D: Bağımlılıkların Ters Çevrimesi İlkesi (Dependency Inversion Principle - DIP): Yüksek seviyeli modüller, düşük seviyeli modüllere bağlı olmamalıdır. Bunun yerine, her iki seviyeli modül de soyutlamalara (interfacelere) dayanmalıdır. Bu, bir uygulamanın parçalarını birbirine bağlamak için arayüzlerin kullanılmasını önerir ve doğrudan sınıflara olan bağımlılığı azaltır.

Bu prensipler, yazılım geliştirme sürecinde kodun daha temiz, daha esnek ve daha sürdürülebilir olmasını sağlamak için kullanılır. SOLID prensiplerinin uygulanması, kod tekrarını azaltır, bakım maliyetlerini düşürür ve gelecekteki değişikliklere uyum sağlamayı kolaylaştırır.
 */