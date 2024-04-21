using Business.Abstracts;
using Business.Concretes;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using System.Reflection;
using Business;     // extension metod ekledikten sonra buray� bazen otomatik doldurmuyor builder.Services.AddBusinessServices(); k�zmas� halinde elimizle ekliyoruz
using DataAccess;   // extension metod ekledikten sonra buray� bazen otomatik doldurmuyor builder.Services.AddDataAccessServices(); k�zmas� halinde elimizle ekliyoruz

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
builder.Services.AddBusinessServices();     // Business i�inde tan�mlad���m�z servis ba��ml�l���n� kulland���m�z� burada belirtiyoruz
builder.Services.AddDataAccessServices();   // DataAccess i�inde tan�mlad���m�z servis ba��ml�l���n� kulland���m�z� burada belirtiyoruz


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionMiddlewareExtensions();  // ExceptionMiddlewareExtensions dosyam�zdaki metodumuzu buraya tan�mlad�k

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
