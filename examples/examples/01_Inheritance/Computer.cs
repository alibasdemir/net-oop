namespace examples._01_Inheritance

/*
 Inheritance, bir sınıfın başka bir sınıftan türetilmesini ifade eder. Türetilen sınıf, miras aldığı sınıfın tüm özelliklerini ve davranışlarını (alanlar, özellikler, metotlar) miras alır.

Temel sınıf, miras veren sınıf olarak adlandırılırken, türetilen sınıf ise alt sınıf veya alt sınıf olarak adlandırılır.
*/

{
    public class Computer   // Üst Sınıf
    {
        public int Id { get; set; }   // Property
        public string CpuBrand { get; set; }
        public string MotherboardBrand { get; set; }
        public string GpuBrand { get; set; }
        public string RamCapacity { get; set; }
        public string SsdSize { get; set; }

        public Computer()   // Constructor
            // bu constructor desktop ve laptop sınıflarına miras olarak aktarılacağı için oluşturulan instance kadar ekrana yazdırılacaktır. (Bu örnekte 2 adet instance oluşturduğumuz için alttaki console 2 defa yazdırılır)
        {
            Console.WriteLine("Computer nesnesi başlatıldı");
        }
    }

    public class Desktop : Computer     // Inheritance (Miras). Desktop Computer'da yer alan tüm özellikleri miras alır.
    {
        public string CaseModel { get; set; }
        public string PsuModel { get; set; }
        public bool LiquidCooling { get; set; }
    }

    public class Laptop : Computer      // Inheritance (Miras). Laptop Computer'da yer alan tüm özellikleri miras alır.
    {
        public string BatteryCapacity { get; set; }
        public string ScreenSize { get; set; }
        public bool TouchScreen { get; set; }
    }

}
