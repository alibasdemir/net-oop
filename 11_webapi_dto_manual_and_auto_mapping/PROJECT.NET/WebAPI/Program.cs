using Business.Abstracts;
using Business.Concretes;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using System.Reflection;
using Business;     // extension metod ekledikten sonra burayý bazen otomatik doldurmuyor builder.Services.AddBusinessServices(); kýzmasý halinde elimizle ekliyoruz
using DataAccess;   // extension metod ekledikten sonra burayý bazen otomatik doldurmuyor builder.Services.AddDataAccessServices(); kýzmasý halinde elimizle ekliyoruz

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
builder.Services.AddBusinessServices();     // Business içinde tanýmladýðýmýz servis baðýmlýlýðýný kullandýðýmýzý burada belirtiyoruz
builder.Services.AddDataAccessServices();   // DataAccess içinde tanýmladýðýmýz servis baðýmlýlýðýný kullandýðýmýzý burada belirtiyoruz


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionMiddlewareExtensions();  // ExceptionMiddlewareExtensions dosyamýzdaki metodumuzu buraya tanýmladýk

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
