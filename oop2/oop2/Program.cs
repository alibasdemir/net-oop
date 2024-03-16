
// reference type
// arrayler reference tipdir, değer tip değil.

int[] sayilar1 = new[] { 1, 2, 3 };     // heap'de {1,2,3} tutuluyor. örneğin sayilar1'in referansına 101 diyelim
int[] sayilar2 = new[] { 10, 20, 30 };  // heap'de {10,20,30} tutuluyor. örneğin sayilar2'nin referansına da 102 diyelim
sayilar1 = sayilar2;    // burdaki esas nokta sayilar1'in 101 olan referans değeri artık sayilar2'nin sahip olduğu 102 olmuş oluyor. Bu durumda 101'i tutan olmadığı için garbage collector (çöp toplayıcı) devreye giriyor ve belleği temizliyor
sayilar2[0] = 1000;     // burda da demek istediğimiz şu oluyor sayilar2 de ki 102'nin 0. elemanı 1000'dir demiş oluyoruz. Yani artık 102'nin 0. elemanı 1000 oluyor. Bu yüzden hem sayilar1 hem de sayilar2'nin 0. elemanı 1000 olmuş oluyor.

Console.WriteLine(sayilar1[0]);     // 1000
Console.WriteLine(sayilar2[0]);     // 1000
Console.ReadLine();
