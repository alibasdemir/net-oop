using Business.Abstracts;
using Business.Concretes;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using System.Reflection;
using Business;     // extension metod ekledikten sonra burayý bazen otomatik doldurmuyor builder.Services.AddBusinessServices(); kýzmasý halinde elimizle ekliyoruz
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;   // extension metod ekledikten sonra burayý bazen otomatik doldurmuyor builder.Services.AddDataAccessServices(); kýzmasý halinde elimizle ekliyoruz

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
builder.Services.AddBusinessServices();     // Business içinde tanýmladýðýmýz servis baðýmlýlýðýný kullandýðýmýzý burada belirtiyoruz
builder.Services.AddDataAccessServices();   // DataAccess içinde tanýmladýðýmýz servis baðýmlýlýðýný kullandýðýmýzý burada belirtiyoruz

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // JWT KONFÝGÜRASYONLARI... 

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        // IssuerSigninKey = ""
        
    };

}); // Sistemimizde Authentication kullanacaðýmýzý söylüyoruz ve hangi yöntemi kullanacaksak onu belirtiyoruz (Jwt -> Microsoft.AspNetCore.Authentication.JwtBearer paketini WebAPI'a kuruyoruz) ve þemamýza (AuthenticationScheme) ekliyoruz. Yani artýk sistemimizin authentication servisinin jwt þemasýyla jwt özellikleriyle kullanýlacaðýný belirtmiþ olduk. Ve AddJwtBearer yazarak jwt þemasýný kullan ve jwt þemasýný da þu özelliklerle kullan demiþ oluyoruz. ----> Bir servisi eklemek o servisi kullanmak anlamýna gelmiyor. Bu tarz yapýlarda ilgili middleware'ýn devreye girmesi için Use komutu vardýr. Biz authentication ekledik ama authentication middleware'ýný devreye almadýk, sadece servis olarak ekledik. Kullanmak için altta Use komutu ile yazacaðýz. app.UseAuthorization(); dan önce app.UseAuthentication(); ekleyerek devreye alýyoruz.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionMiddlewareExtensions();  // ExceptionMiddlewareExtensions dosyamýzdaki metodumuzu buraya tanýmladýk

app.UseHttpsRedirection();

app.UseAuthentication();    // Authentication middleware'ýnýn devreye girmesi için bunu ekledik. Sýralama önemlidir. Authentication, authorizationdan önce çalýþýr. Bu önemli...

app.UseAuthorization();

app.MapControllers();

app.Run();
