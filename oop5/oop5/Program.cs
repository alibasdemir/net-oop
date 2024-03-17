
// ABSTRACT CLASS
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

interface ICreditManager
{
    void Calculate();   // hesaplama her yerde farklı şekilde tanımlanıyor ama alttaki save heryerde aynı şekilde tanımlı.
    void Save();        // TeacherCreditManager, MilitaryCreditManager, CarCreditManager içinde yer alan tüm Save operasyonları aynı. Programlamada DRY isimli bir prensip vardır yani "Don't Repeat Yourself (Kendini Tekrarlama)" Ama biz bu prensibi uygulayamadık neden çünkü Save methodumuzu tekrarlamış olduk. Bunu önlemek için bir "abstract class" oluşturuyoruz ve bu save methodunu ortak bir şekilde yazıyoruz: "abstract class BaseCreditManager : ICreditManager"
}

abstract class BaseCreditManager : ICreditManager
{
    public abstract void Calculate();   // Calculate operasyonu bizim için değişken birşey (yani her yerde farklı hesaplama kullanıyoruz) bu yüzden abstract yazıyoruz: "public abstract void" ---> TAMAMLANMAMIŞ OPERASYON

    public void Save()      // ve save operasyonumuzu tanımladık ve bu noktadan sonra tüm creditManager'larımızı BaseCreditManager'dan inherit edeceğiz. (TeacherCreditManager, MilitaryCreditManager, CarCreditManager) ---> TAMAMLANMIŞ YANİ İÇİ DOLDURULMUŞ OPERASYON

    // *** NOT: *** Örneğin ilerleyen zamanlarda herhangi bir operasyonumuzda save methodumuzu farklı kullanmak istersek veya save methodumuzun içinde farklı bir işlem daha yapmak istedik diyelim. Bu durumda "public virtual void" olarak tanımlamamız gerekiyor. Bu Save yapısını değiştirmeden yeniden yazarak alta yorum satırında örnek olarak oluşturuyorum. ve öğretmen kredisi için değişiklik yapacağımızı düşünelim bu örneği de TeacherCreditManager içinde yorum satırına yazıyorum
    {
        Console.WriteLine("Kaydedildi.");
    }

    // PUBLIC VIRTUAL VOID ÖRNEĞİ
    /* 
    public virtual void Save()
    {
        Console.WriteLine("Kaydedildi.");
    }
    */
}

class TeacherCreditManager : BaseCreditManager, ICreditManager  // BaseCreditManager'dan inherit edilecek ve artık burda Save() operasyonumuza ihtiyaç kalmayacak ve save operasyonunu burdan kaldırıyoruz. Ayrıca BaseCreditManager'da ki calculate operasonumuzu override etmeliyiz.
{
    public override void Calculate()    // BaseCreditManager'da ki calculate operasyonumuzu kullandık ve burayı override ettik. "public override void" Yani Calculate operasyonum ortak değil üzerine yaz demiş oluyoruz
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
    /*
    public override void Save() // değişiklik, ekleme vs yapmak istediğimiz save operasyonumuz
    {
        // burada istediğimizi ekleyebiliriz, istediğimiz değişikliği yapabiliriz
        base.Save();    // base demek inherit ettiği sınıf
        // burada da istediğimizi ekleyebiliriz, istediğimiz değişikliği yapabiliriz
        // Yani Save()'i silebiliriz, Save'den önce başka bir kod ekleyip çalıştırabiliriz, Save'den sonra başka bir kod ekleyip çalıştırabiliriz.
    }
    */
}

class MilitaryCreditManager : BaseCreditManager, ICreditManager     // TeacherCreditManager'da uyguladığımız aynı mantığı buraya da uyguluyoruz. *** TÜM AÇIKLAMALAR TeacherCreditManager'DA YER ALIYOR ***
{
    public override void Calculate()
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
}

class CarCreditManager : BaseCreditManager, ICreditManager // TeacherCreditManager'da uyguladığımız aynı mantığı buraya da uyguluyoruz. *** TÜM AÇIKLAMALAR TeacherCreditManager'DA YER ALIYOR ***
{
    public override void Calculate() 
    {
        // 
        //
        //
        //  BU KISIMDA HESAPLAMALAR YER ALIR
        //
        //
        //
        Console.WriteLine("Araba Kredisi Hesaplandı.");
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
    public CustomerManager(Customer customer, ICreditManager creditManager)
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

    public void GiveCredit()
    {
        _creditManager.Calculate();
        Console.WriteLine("Kredi Verildi");
    }
}
