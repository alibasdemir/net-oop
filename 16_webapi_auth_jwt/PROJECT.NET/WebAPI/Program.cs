using Business.Abstracts;
using Business.Concretes;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using System.Reflection;
using Business;     // extension metod ekledikten sonra buray� bazen otomatik doldurmuyor builder.Services.AddBusinessServices(); k�zmas� halinde elimizle ekliyoruz
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;   // extension metod ekledikten sonra buray� bazen otomatik doldurmuyor builder.Services.AddDataAccessServices(); k�zmas� halinde elimizle ekliyoruz

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
builder.Services.AddBusinessServices();     // Business i�inde tan�mlad���m�z servis ba��ml�l���n� kulland���m�z� burada belirtiyoruz
builder.Services.AddDataAccessServices();   // DataAccess i�inde tan�mlad���m�z servis ba��ml�l���n� kulland���m�z� burada belirtiyoruz

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // JWT KONF�G�RASYONLARI... 

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        // IssuerSigninKey = ""
        
    };

}); // Sistemimizde Authentication kullanaca��m�z� s�yl�yoruz ve hangi y�ntemi kullanacaksak onu belirtiyoruz (Jwt -> Microsoft.AspNetCore.Authentication.JwtBearer paketini WebAPI'a kuruyoruz) ve �emam�za (AuthenticationScheme) ekliyoruz. Yani art�k sistemimizin authentication servisinin jwt �emas�yla jwt �zellikleriyle kullan�laca��n� belirtmi� olduk. Ve AddJwtBearer yazarak jwt �emas�n� kullan ve jwt �emas�n� da �u �zelliklerle kullan demi� oluyoruz. ----> Bir servisi eklemek o servisi kullanmak anlam�na gelmiyor. Bu tarz yap�larda ilgili middleware'�n devreye girmesi i�in Use komutu vard�r. Biz authentication ekledik ama authentication middleware'�n� devreye almad�k, sadece servis olarak ekledik. Kullanmak i�in altta Use komutu ile yazaca��z. app.UseAuthorization(); dan �nce app.UseAuthentication(); ekleyerek devreye al�yoruz.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionMiddlewareExtensions();  // ExceptionMiddlewareExtensions dosyam�zdaki metodumuzu buraya tan�mlad�k

app.UseHttpsRedirection();

app.UseAuthentication();    // Authentication middleware'�n�n devreye girmesi i�in bunu ekledik. S�ralama �nemlidir. Authentication, authorizationdan �nce �al���r. Bu �nemli...

app.UseAuthorization();

app.MapControllers();

app.Run();
