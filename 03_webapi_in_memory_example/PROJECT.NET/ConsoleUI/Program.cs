using ConsoleUI;

// İLGİLİ KALIPTAN ÜRETİLEN BİR ÖRNEKTİR. (INSTANCE)
Product product = new Product();    // BU BİR INSTANCE'DIR
product.Name = "Kazak";
product.Id = 1;

Product product1 = new Product(2, "Elma");  // Product.cs 'de oluşturduğumuz parametreli ctor için kullanım şekli

// C# 8 İLE GELEN ÖZELLİKLER new anahtar sözcüğünden sonra Product yazma zorunluluğumuz yok. Çünkü solda Product diye tanımlıyoruz ve bunu artık otomatik olarak algılıyor 
Product product2 = new(3, "Armut");

Console.WriteLine(product.Name);
Console.WriteLine(product1.Name);
Console.WriteLine(product2.Name);


Customer customer = new Customer();
// USER'DAN INHERIT ETTİĞİMİZ ÖZELLİKLER:
customer.FirstName = "Ali";
customer.LastName = "Veli";
customer.Email = "ali@deneme.com";
customer.Password = "1234";
// CUSTOMER'A ÖZEL ÖZELLİK:
customer.TaxNo = "55555";


User user = new Admin();        // POLYMORPHISM User tanımladım ve Admin new'ledim. Admin'e User'daki tüm özellikleri miras aldım ve bu şekilde kullanım sağlayabildim. İşte bu durum bir polymorphism'dir. (Yani User'ımız hem admin olabiliyor hem customer olabiliyor)
User user2 = new Customer();    // POLYMORPHISM
// NOT: INHERITANCE OLMADAN POLYMORPHISM OLMAZ.
Console.ReadLine();

// OOP CONCEPTS ---> ACCESS MODIFIERS, CONSTRUCTOR,  INHERITANCE, POLYMORPHISM
// ABSTRACTION, INTERFACE  