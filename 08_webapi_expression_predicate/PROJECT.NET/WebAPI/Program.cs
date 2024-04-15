using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductManager>();   // IProductService geldi�i zaman ProductManager d�nd�r demi� oluyoruz. IOC'e yani konteynara bir konfig�rasyon eklemi� olduk. Yani bu soyut class�n (IProductService) kar��l��� bu somut classt�r (ProductManager) demi� olduk.
// Singleton - Scoped - Transient ---> BUNLAR LIFETIME'DIR.
// Singleton => �retilen ba��ml�l�k uygulama a��k oldu�u s�rece tek bir kere new'lenir. Her enjeksiyonda o instance kullan�l�r.

// Scoped    => �stek (API iste�i) ba��na 1 instance olu�turur.
// Transient => Her ad�mda (her talepte) yeni 1 instance olu�turur.

// builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

builder.Services.AddScoped<IProductRepository, EfProductRepository>();   // Bu yap� ile sistemimiz art�k InMemory yerine EntityFramework yap�s� kullanacak. �stteki InMemory yap�s�n� yorum sat�r�na al�yoruz ve sistemi EntityFramework kullanan yap� haline getiriyoruz.

// NOT: SOYUTLAMA KULLANDI�IMIZ HER NOKTADA O SOYUTLAMANIN KAR�ILI�I OLARAK S�STEMDE SOMUT OLARAK HANG�S� KULLANILACAK BUNU BEL�RTMEM�Z GEREK�YOR. Yani yukar�dakiler gibi �rne�in IProductService i�in ProductManager. ve IProductRepository i�in InMemoryProductRepository. �eklinde belirtmemiz gerekiyor.

builder.Services.AddDbContext<BaseDbContext>();     // Veritaban�m�z� tan�mlayan BaseDbContext bir ba��ml�l�kt�r bu y�zden bunu servislere eklememiz gerekir. Bu y�zden buraya ekliyoruz.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
