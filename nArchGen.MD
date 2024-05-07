**Download Link :**
https://github.com/kodlamaio-projects/nArchitecture.Gen.git

**Kullanım Adımları**
1- Projeyi aç
2- Rebuild Solution
3- ConsuleUI sağ click -> Open Folder in File Explorer
4- bin -> Debug -> net8.0   (Assembly/dlls-> Projenin çalışabilir hale geldiği doyalar)
5- Pathi kopyala
6- Windows Arama -> System environment variables (Sistem Ortam Değişkenleri)
7- Environment variables (Ortam Değişkenleri)
8- Sistem Değişkenleri içinde Path -> Düzenle
9- Yeni -> Kopyaladığımız path'i yapıştırıyoruz
10- cmd -> narchgen yazarak sistem tarafından tanınıp tanınmadığını kontrol ediyoruz
11- narchgen ile projeyi nerede başlatmak istiyorsak cmd'de o path'e gelip -> narchgen new yazıyoruz
12- Proje ismini yazıyoruz
13- Sistemimize güvenlik mekanizması ekleyip eklememek istediğimizi soruyor (JWT kullanacaksak y, public bir proje olacaksa n yazıyoruz)
14- Belirlediğimiz path'e projeyi oluşturuyor. Projeyi açıyoruz
15- src klasörü altında hazır bir şekilde onion arch oluşturdu. (Core paketi mevcut değil ancak, Core paketi nuGet paketleri halinde mevcut. nuget package manager'da yer alıyor)
16- Core paketlerini parça parça, hangi paketi kullanmak istiyorsak buradan yükleyip kullanabiliyoruz -> NArchitecture.Core şeklinde arayarak ulaşabiliyoruz