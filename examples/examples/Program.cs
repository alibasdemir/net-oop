using examples._01_Inheritance;
using examples._02_Polymorphism;
using examples._03_Interface;
using examples._05_GenericType;
using examples._06_Encapsulation;
using examples.AbstractClass;

namespace examples
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1 - Computer.cs (inheritance)
            Desktop desktop = new Desktop();    // Instance
            // desktop computer'da yer alan tüm özellikleri miras aldı ve tanımlama yapılabildi
            desktop.Id = 1;
            desktop.CpuBrand = "Amd";
            desktop.MotherboardBrand = "Asus";
            desktop.GpuBrand = "Msi 4070";
            desktop.RamCapacity = "32gb";
            desktop.SsdSize = "512gb";
            desktop.CaseModel = "Corsair Micro-ATX";
            desktop.PsuModel = "Corsair 1000w";
            desktop.LiquidCooling = true;

            Laptop laptop = new Laptop();       // Instance
            // laptop computer'da yer alan tüm özellikleri miras aldı ve tanımlama yapılabildi
            laptop.Id = 2;
            laptop.CpuBrand = "Intel";
            laptop.MotherboardBrand = "Gigabyte";
            laptop.GpuBrand = "Intel UHD Graphics";
            laptop.RamCapacity = "32gb";
            laptop.SsdSize = "512gb";
            laptop.BatteryCapacity = "42wh";
            laptop.ScreenSize = "15.6";
            laptop.TouchScreen = false;

            Laptop laptop2 = new Laptop();


            Console.WriteLine($"Id: {laptop.Id}, CpuBrand: {laptop.CpuBrand}, MotherboardBrand: {laptop.MotherboardBrand}, GpuBrand: {laptop.GpuBrand}, RamCapacity: {laptop.RamCapacity}, SsdSize: {laptop.SsdSize}, BatteryCapacity: {laptop.BatteryCapacity}, ScreenSize: {laptop.ScreenSize}, TouchScreen: {laptop.TouchScreen}");

            Console.WriteLine($"Id: {desktop.Id}, CpuBrand: {desktop.CpuBrand}, MotherboardBrand: {desktop.MotherboardBrand}, GpuBrand: {desktop.GpuBrand}, RamCapacity: {desktop.RamCapacity}, SsdSize: {desktop.SsdSize}, CaseModel: {desktop.CaseModel}, PsuModel: {desktop.PsuModel}, LiquidCooling: {desktop.LiquidCooling}");

            Console.WriteLine("********************");

            // 2 - Vehicle.cs (inheritance)
            Airplane airplane = new Airplane();
            airplane.Brand = "Boeing";
            airplane.Year = 2020;
            airplane.WingCount = 2;
            airplane.PassengerCapacity = 300;

            Ship ship = new Ship();
            ship.Brand = "Royal Caribbean";
            ship.Year = 2015;
            ship.ShipType = "Cruise Ship";
            ship.CarryingCapacity = 5000;

            Console.WriteLine("Airplane Brand: " + airplane.Brand);

            Console.WriteLine("Ship Type: " + ship.ShipType);

            Console.WriteLine("********************");

            // 3 - Animal.cs (inheritance)
            Cat cat = new Cat(4, "female", "British");
            Dog dog = new Dog(6, "male", "protective");
            dog.DisplayDogDetails();

            Console.WriteLine("********************");

            // 4 - Animal2.cs (polymorphism)
            Animal2[] animal2 = new Animal2[3];
            animal2[0] = new Sheep();
            animal2[1] = new Bird();
            animal2[2] = new Cow();

            foreach (var animals in animal2)
            {
                animals.Sound(); // Her bir nesne aynı metodu çağırır, ancak farklı davranır.
            }

            Duck duck = new Duck();
            duck.Sound();

            Console.WriteLine("********************");

            // 5 - Pass.cs (polymorphism/interface)
            IPass[] passes = new IPass[3];
            passes[0] = new StudentPass();
            passes[1] = new StaffPass();
            passes[2] = new VisitorPass();

            foreach (var pass in passes)
            {
                pass.Scan(); // Her bir nesne aynı metodu çağırır, ancak farklı davranır.
            }

            Console.WriteLine("********************");

            // 6 - IPrintable.cs (interface)
            // IPrintable interface'ini kullanarak Rectangle ve Circle nesneleri oluşturuluyor
            IPrintable rectangle = new Rectangle();
            IPrintable circle = new Circle();

            // Her ikisi de Print metodunu çağırabilir
            rectangle.Print();
            circle.Print();

            Console.WriteLine("********************");

            // 7 - AbstractPrintable.cs (Abstract Class)
            // AbstractPrintable sınıfından türetilen Rectangle ve Circle nesneleri oluşturuluyor
            AbstractPrintable rectangle2 = new Rectangle2();
            AbstractPrintable circle2 = new Circle2();

            // Her ikisi de Print metodunu çağırabilir
            rectangle2.Print();
            circle2.Print();

            Console.WriteLine("********************");

            // 8 - Kutu.cs (Generic Type)
            Kutu<string> stringKutu = new Kutu<string>("Merhaba Dünya");
            Console.WriteLine("String Kutu İçeriği: " + stringKutu.Icerik);
            Kutu<int> intKutu = new Kutu<int>(42);
            Console.WriteLine("Integer Kutu İçeriği: " + intKutu.Icerik);
            Kutu<double> doubleKutu = new Kutu<double>(3.14);
            Console.WriteLine("Double Kutu İçeriği: " + doubleKutu.Icerik);
            Kutu<char> charKutu = new Kutu<char>('A');
            Console.WriteLine("Char Kutu İçeriği: " + charKutu.Icerik);

            Console.WriteLine("********************");

            // 9 - BankaHesabi.cs (Encapsulation)
            BankaHesabi hesap = new BankaHesabi("Ali", 1000);
            // Bakiyeyi görüntüleme
            Console.WriteLine($"Mevcut bakiye: {hesap.GetBakiye()} TL");
            // Para yatırma işlemi
            hesap.SetParaYatir(500);
            // Para çekme işlemi
            hesap.SetParaCek(500);


            Console.ReadLine();
        }
    }
}
