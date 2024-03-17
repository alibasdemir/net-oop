
// INTERFACE

// Mülakatta interface nedir, abstract class ile arasındaki fark nedir şeklinde soru kesin gelir. Bu yüzden bu konular önemli.

// interfaceler iş yapan operasyonların yani bu örnekte CreditManager veya CustomerManager imza seviyesinde yazarak yazılımda bağımlılığı korumak adına yapılan çalışma diyebiliriz. Örneğin CreditManager altında bir bankayı düşünelim bankada çiftçi kredisi, esnaf kredisi, öğretmen kredisi, ihtiyaç kredisi, taşıt kredisi, ev kredisi vs var ve hepsinin hesaplanma yöntemi farklıdır. Hepsini CreditManager altında if/else ile ayrı ayrı tanımlayabiliriz ancak bu doğru bir yapı olmaz ve test araçlarında "sonar qube" gibi ne kadar if kullandığımız bile ölçülür, bu tarz nesne yönelimli programlamalarda çok fazla if kullanmak doğru değildir. İşte bu tarz durum için interface kullanırız.

// Not: interface'ler referans tiplerdir. 
// Not2: interface'lerin amacı yazılımdaki bağımlılıkları engellemek if'lerden kurtulmaktır.
// Not3: Sistemlerdeki değişiklik taleplerini karşılamak için bu yapıyı kullanırız. Örneğin loglama altyapımızı değiştireceğiz, sql ile çalışırken başka bir müşteri oracle ile çalışıyorsa ve sistemi ona geçireceksek veya yeni bir kredi türü ekleyeceğiz örneğin CarCredit diyelim, ekleyip sorunsuz bir şekilde kullanabiliyoruz
class Program
{
    static void Main(string[] args)
    {
        CustomerManager customerManager = new CustomerManager(new Customer(), new MilitaryCreditManager());
        customerManager.GiveCredit();

        CustomerManager customerManager2 = new CustomerManager(new Customer(), new TeacherCreditManager());
        customerManager2.GiveCredit();

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

interface ICreditManager    // interface'imizi oluşturduk ve CreditManager'in içinde yer almasını istediğimiz operasyonlarımızı alttaki gibi yazdık ve bunların imzasını yazmış olduk (yani metodun sadece ne döndürdüğünü, ismini ve parametrelerini yazdık bu kadar) 
{
    void Calculate();   // hesaplama operasyonumuzu ekledik - imza
    void Save();        // save operasyonumuzu ekledik - imza
}

class TeacherCreditManager : ICreditManager      // öğretmenlere verilen kredi ekledik - : ICreditManager ekledikten sonra altını çizer çünkü metodları getirip doldurmamız gerekir. Kırmızı çiziliyken üstüne tıkladığımız zaman ampül yanar ve ona basınca "implement interface" e basarak getirir
{
    public void Calculate()
    {
        // 
        //
        //
        //  BU KISIMDA HESAPLAMALAR YER ALIR
        //
        //
        //
        Console.WriteLine("Öğretmen Kredisi Hesaplandı.");
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}

class MilitaryCreditManager : ICreditManager    // askerlere verilen kredi ekledik - : ICreditManager ekledikten sonra altını çizer çünkü metodları getirip doldurmamız gerekir. Kırmızı çiziliyken üstüne tıkladığımız zaman ampül yanar ve ona basınca "implement interface" e basarak getirir
{
    public void Calculate()
    {
        // 
        //
        //
        //  BU KISIMDA HESAPLAMALAR YER ALIR
        //
        //
        //
        Console.WriteLine("Asker Kredisi Hesaplandı.");
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}

class Customer
{
    public Customer()
    {
        Console.WriteLine("müşteri nesnesi başlatıldı");
    }
    public int Id { get; set; }
    public string Identity { get; set; }
    public string City { get; set; }

}

class Company : Customer
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
    private ICreditManager _creditManager;  // parametre olarak ekledik
    public CustomerManager(Customer customer, ICreditManager creditManager)     // parametre olarak interface'imizi verdik.. Aslında burdaki "ICreditManager creditManager" olay polimorfizmdir(çok biçimlilik). Yani biz buraya ICreditManager diyoruz ama istediğimiz biçimi kullanabiliyoruz. En altta GiveCredit'e farklı biçimlerde davranış sergiletiyoruz. Teacher, Military credisi gibi farklı biçimler
    {
        _customer = customer;
        _creditManager = creditManager;
    }
    public void Save()
    {
        Console.WriteLine("Müşteri Kaydedildi: ");
    }
    public void Delete()
    {
        Console.WriteLine("Müşteri Silindi: ");
    }

    public void GiveCredit()    // Müşteriye kredi vereceğiz bu yüzden bu operasyonu oluşturduk
    {
        _creditManager.Calculate();     // Önce hesaplama yapıyoruz ve daha sonra hesaplama sonucuna göre krediyi veriyoruz --- GiveCredit'e farklı biçimlerde davranış sergiletiyoruz. Teacher, Military credisi gibi farklı biçimleri hesaplatıyoruz bu yüzden polimorfizm oluyor.
        Console.WriteLine("Kredi Verildi");
    }
}
