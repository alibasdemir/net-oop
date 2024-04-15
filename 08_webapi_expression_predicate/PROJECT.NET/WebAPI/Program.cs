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

builder.Services.AddScoped<IProductService, ProductManager>();   // IProductService geldiði zaman ProductManager döndür demiþ oluyoruz. IOC'e yani konteynara bir konfigürasyon eklemiþ olduk. Yani bu soyut classýn (IProductService) karþýlýðý bu somut classtýr (ProductManager) demiþ olduk.
// Singleton - Scoped - Transient ---> BUNLAR LIFETIME'DIR.
// Singleton => Üretilen baðýmlýlýk uygulama açýk olduðu sürece tek bir kere new'lenir. Her enjeksiyonda o instance kullanýlýr.

// Scoped    => Ýstek (API isteði) baþýna 1 instance oluþturur.
// Transient => Her adýmda (her talepte) yeni 1 instance oluþturur.

// builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

builder.Services.AddScoped<IProductRepository, EfProductRepository>();   // Bu yapý ile sistemimiz artýk InMemory yerine EntityFramework yapýsý kullanacak. üstteki InMemory yapýsýný yorum satýrýna alýyoruz ve sistemi EntityFramework kullanan yapý haline getiriyoruz.

// NOT: SOYUTLAMA KULLANDIÐIMIZ HER NOKTADA O SOYUTLAMANIN KARÞILIÐI OLARAK SÝSTEMDE SOMUT OLARAK HANGÝSÝ KULLANILACAK BUNU BELÝRTMEMÝZ GEREKÝYOR. Yani yukarýdakiler gibi örneðin IProductService için ProductManager. ve IProductRepository için InMemoryProductRepository. þeklinde belirtmemiz gerekiyor.

builder.Services.AddDbContext<BaseDbContext>();     // Veritabanýmýzý tanýmlayan BaseDbContext bir baðýmlýlýktýr bu yüzden bunu servislere eklememiz gerekir. Bu yüzden buraya ekliyoruz.

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
