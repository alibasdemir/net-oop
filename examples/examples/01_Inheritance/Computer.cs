namespace examples._01_Inheritance
{
    public class Computer   // Üst Sınıf
    {
        public int Id { get; set; }   // Property
        public string CpuModel { get; set; }
        public string MotherboardModel { get; set; }
        public string RamModel { get; set; }
        public string SsdModel { get; set; }
        public string GpuModel { get; set; }

        public Computer()   // Constructor
        {
            Console.WriteLine("Computer nesnesi başlatıldı");
        }
    }

    public class Desktop : Computer
    {
        public string CaseModel { get; set; }
        public string PsuModel { get; set; }
        public bool LiquidCooling { get; set; }

    }

    public class Laptop : Computer
    {
        public string BatteryCapacity { get; set; }
        public string ScreenSize { get; set; }
        public string Color { get; set; }
        public bool TouchScren { get; set; }
    }
}
