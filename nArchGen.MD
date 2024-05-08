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

**Kurulum Sonrası Kullanım Adımları**

1- Sistemi kurduk ve kendi entity'lerimizi eklemek istediğimiz aşamada BaseDbContext'te default olarak inmemory çalışan alanı sql'e çeviriyoruz (inmemory çalışmak istiyorsak değiştirmemize gerek yok)
2- Package Manager Console -> Default Project: Persistence
3- Add-Migration Init
4- Update-Database
5- Seed data ile tablo içerikleri oluşuyor
6- Entity ekle -> Örneğin Brand entity ekleyelim
7- Brand Entityden inherit edilerek Entity id türü int olarak kısıtlanmadan istediğimiz türde kullanılabilir. Örneğin GUID kullanabiliriz
8- Normalde Brand entity'mizi oluşturduktan sonra Persistence'da Repository oluştururduk sonra Application'da Feature ve Service oluştururduk ve sonra da WebAPI ile dış dünyaya açardık. nArch bunu otomatik olarak algılayarak bizim yerimize oluşturuyor:
9- Terminal -> cd src -> cd projeKonumu -> narchgen -> narchgen generate ---> bu adımlardan sonra crud, command, query seçeneklerini göreceğiz
10- narchgen generate crud -> yazdığımızda bizim entity'lerimizi otomatik olarak tarayarak hangi entity için crud işlemlerini generate etmek istediğimizi seçebilmemizi sağlan seçenekler sunacak
11- Yeni eklediğimiz Brand'i seçiyoruz. Bize hangi veritabanı context'i altında Brand'i eklemek istediğimizi soracak ve uygun olanı seçiyoruz (Bu projede BaseDbContext)
12- Ardından hangi mekanizmaları kullanmak istediğimizi soruyor -> Caching, Logging, Transaction, Secured Operation (Örneğin oluşturacağımız kodlar loglansın mı, secured mi olsun, cache'lensin mi gibi istediklerimizi space ile işaretleyip kullanabiliyoruz) Bu projede sadece loglamayı seçiyoruz.
- Brand entity'mizi seçtiğimiz context'e ekliyor (BaseContext)
- Persistence katmanı kodlarını oluşturuyor. BrandRepository'i oluşturuyor, Configuration'ları ekliyor. Registration dahil tüm Persistence katmanı dosyalarını yazıyor
- Application katmanı kodlarını oluşturuyor. Brand'e özel servis oluşturuyor, içerisine kullanabileceğimiz en temel kodları yazıyor (silme, ekleme, güncelleme, getirme, id'ye göre getirme vs) Feature'da temel 3 command'ı ve temel 2 query'i yazıyor. MappingProfile'ları otomatik kendisi yapıyor
- WebAPI'ya gidip dış dünyaya açıyor (BrandController)

**ÖNEMLİ NOT:** Ancak db'ye oto migrate işlemi gerçekleştirmez. Tüm işlemlerden sonra migrate etmeyi ve db'yi update etmeyi unutmuyoruz. (Brand ile devam edelim -> Add-Migration AddBrand -> Update-Database)