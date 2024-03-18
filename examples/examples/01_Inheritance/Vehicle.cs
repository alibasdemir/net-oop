namespace examples._01_Inheritance
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public int Year { get; set; }
    }

    public class Airplane : Vehicle
    {
        public int WingCount { get; set; }
        public int PassengerCapacity { get; set; }

        public Airplane()   // Airplane sınıfının kendine ait constructor'ı 
        {
            Console.WriteLine("Uçak nesnesi başlatıldı");
        }
    }

    public class Ship : Vehicle
    {
        public string ShipType { get; set; }
        public int CarryingCapacity { get; set; }

        public Ship()   // Ship sınıfının kendine ait constructor'ı 
        {
            Console.WriteLine("Gemi nesnesi başlatıldı");
        }
    }
}
