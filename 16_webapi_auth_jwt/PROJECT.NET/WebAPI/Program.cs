using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Business;     // extension metod ekledikten sonra buray� bazen otomatik doldurmuyor builder.Services.AddBusinessServices(); k�zmas� halinde elimizle ekliyoruz
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;   // extension metod ekledikten sonra buray� bazen otomatik doldurmuyor builder.Services.AddDataAccessServices(); k�zmas� halinde elimizle ekliyoruz

using TokenOptions = Core.Utilities.JWT.TokenOptions;
using Core.Utilities.Encryption;
using Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();   // T�m TokenOptions alanlar�n� obje alarak ald�k ve t�m verileri burada okuyabildik. �stteki gibi tek tek okumuyoruz. �rne�in yukar�da ki gibi tek tek okursak Issuer alan� laz�m oldu�u zaman yine ayn� kodu yaz�p securitykey yerine issuer yazmam�z gerekecekti. ama bu sayede hepsini bir obje olarak al�p okuyabiliyoruz


builder.Services.AddHttpContextAccessor();  // ProductsControllere ekledi�imiz ba��ml�l��� kullanmak i�in ekliyoruz.
builder.Services.AddBusinessServices();     // Business i�inde tan�mlad���m�z servis ba��ml�l���n� kulland���m�z� burada belirtiyoruz
builder.Services.AddDataAccessServices();   // DataAccess i�inde tan�mlad���m�z servis ba��ml�l���n� kulland���m�z� burada belirtiyoruz
builder.Services.AddCoreServices(tokenOptions);         // Core i�inde tan�mlad���m�z servis ba��ml�l���n� kulland���m�z� burada belirtiyoruz. ---> CoreServiceRegistration'da verdi�imiz tokenOptions parametresini buraya ekledik.

// string securityKey = builder.Configuration.GetSection("TokenOptions").GetValue<string>("SecurityKey");       // appsettings.Development.json dosyam�zdan veri okuyabilmemizi sa�lar ---> appsettings.Development.json dosyam�zdaki TokenOptions b�l�m�n� al ve bu b�l�mdeki SecurityKey alan�n� oku. (GetValue'nun i�ine get edece�imiz verinin t�r�n� yaz�yoruz) GetValue yerine Get(); yazarsak TokenOptions alan�ndaki t�m verileri obje halinde al�yor


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // JWT KONF�G�RASYONLARI... 

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,      // token�n issuer alan�n� validate et
        ValidateAudience = true,    // token�n audience alan�n� validate et
        ValidateLifetime = true,    // token�n lifetime alan�n� validate et
        ValidateIssuerSigningKey = true,    // do�ru ki�i taraf�ndan imzalan�p imzalanmad���n� yani security keyimiz ile imzalan�p imzalanmad��� kontrol�
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)       // appsettings.Development'ta bulunduraca��m�z security key ile imzalanm�� bir anahtar. genellikle bu security keyler 256bit olarak yaz�l�r ve s�kl�kla de�i�tirilir (key generator siteleri kullan�labilir) Amac�m�z ele ge�irilmesi ve ��z�mlenmesini zorla�t�rmak.
        
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
