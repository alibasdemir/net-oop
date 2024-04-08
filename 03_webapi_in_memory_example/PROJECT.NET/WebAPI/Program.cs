using Business.Abstracts;
using Business.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductService, ProductManager>();   // IProductService geldiði zaman ProductManager döndür demiþ oluyoruz. IOC'e yani konteynara bir konfigürasyon eklemiþ olduk. Yani bu soyut classýn (IProductService) karþýlýðý bu somut classtýr (ProductManager) demiþ olduk.
// Singleton - Scoped - Transient ---> BUNLAR LIFETIME'DIR.
// Singleton => Üretilen baðýmlýlýk uygulama açýk olduðu sürece tek bir kere new'lenir. Her enjeksiyonda o instance kullanýlýr.

// Scoped    => Ýstek (API isteði) baþýna 1 instance oluþturur.
// Transient => Her adýmda (her talepte) yeni 1 instance oluþturur.

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
