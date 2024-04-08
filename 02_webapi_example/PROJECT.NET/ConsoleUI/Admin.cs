namespace ConsoleUI
{
    public class Admin : User       // INHERITANCE
    {
        // INHERTITANCE YAPARAK ADMIN'IN USER'IN SAHİP OLDUĞU TÜM HERŞEYİ MİRAS ALMASINI SAĞLADIK
        public string Role { get; set; }    // Admin' özel field ekledik
    }
}
