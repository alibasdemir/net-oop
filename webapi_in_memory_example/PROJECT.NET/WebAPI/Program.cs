using Business.Abstracts;
using Business.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductService, ProductManager>();   // IProductService geldi�i zaman ProductManager d�nd�r demi� oluyoruz. IOC'e yani konteynara bir konfig�rasyon eklemi� olduk. Yani bu soyut class�n (IProductService) kar��l��� bu somut classt�r (ProductManager) demi� olduk.
// Singleton - Scoped - Transient ---> BUNLAR LIFETIME'DIR.
// Singleton => �retilen ba��ml�l�k uygulama a��k oldu�u s�rece tek bir kere new'lenir. Her enjeksiyonda o instance kullan�l�r.

// Scoped    => �stek (API iste�i) ba��na 1 instance olu�turur.
// Transient => Her ad�mda (her talepte) yeni 1 instance olu�turur.

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
