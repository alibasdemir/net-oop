﻿namespace ConsoleUI
{
    // NOT: ÖRNEĞİN BURADA OLUŞTURDUĞUMUZ DİĞER CLASS'LAR İÇİN ONLARA ÖZEL FILE OLUŞTURMAK VE ORAYA GÖNDERMEK İÇİN OLUŞTURDUĞUMUZ CLASS İSMİNİN SONUNA TIKLAYIP "CTRL + ." BASIYORUZ VE "MOVE TYPE TO CLASSİSMİ.CS" E TIKLIYORUZ

    public class Customer : User    // INHERITANCE
    {
        // INHERITANCE YAPARAK CUSTOMER'IN USER'IN SAHİP OLDUĞU TÜM HERŞEYİ İÇERECEĞİNİ BELİRTMİŞ OLDUK
        public string TaxNo { get; set; }   // VE SADECE CUSTOMER'IN İÇERECEĞİ BİR FIELD EKLEDİK
    }
}
