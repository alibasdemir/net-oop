using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Business;     // extension metod ekledikten sonra burayý bazen otomatik doldurmuyor builder.Services.AddBusinessServices(); kýzmasý halinde elimizle ekliyoruz
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;   // extension metod ekledikten sonra burayý bazen otomatik doldurmuyor builder.Services.AddDataAccessServices(); kýzmasý halinde elimizle ekliyoruz

using TokenOptions = Core.Utilities.JWT.TokenOptions;
using Core.Utilities.Encryption;
using Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();   // Tüm TokenOptions alanlarýný obje alarak aldýk ve tüm verileri burada okuyabildik. Üstteki gibi tek tek okumuyoruz. Örneðin yukarýda ki gibi tek tek okursak Issuer alaný lazým olduðu zaman yine ayný kodu yazýp securitykey yerine issuer yazmamýz gerekecekti. ama bu sayede hepsini bir obje olarak alýp okuyabiliyoruz


builder.Services.AddHttpContextAccessor();  // ProductsControllere eklediðimiz baðýmlýlýðý kullanmak için ekliyoruz.
builder.Services.AddBusinessServices();     // Business içinde tanýmladýðýmýz servis baðýmlýlýðýný kullandýðýmýzý burada belirtiyoruz
builder.Services.AddDataAccessServices();   // DataAccess içinde tanýmladýðýmýz servis baðýmlýlýðýný kullandýðýmýzý burada belirtiyoruz
builder.Services.AddCoreServices(tokenOptions);         // Core içinde tanýmladýðýmýz servis baðýmlýlýðýný kullandýðýmýzý burada belirtiyoruz. ---> CoreServiceRegistration'da verdiðimiz tokenOptions parametresini buraya ekledik.

// string securityKey = builder.Configuration.GetSection("TokenOptions").GetValue<string>("SecurityKey");       // appsettings.Development.json dosyamýzdan veri okuyabilmemizi saðlar ---> appsettings.Development.json dosyamýzdaki TokenOptions bölümünü al ve bu bölümdeki SecurityKey alanýný oku. (GetValue'nun içine get edeceðimiz verinin türünü yazýyoruz) GetValue yerine Get(); yazarsak TokenOptions alanýndaki tüm verileri obje halinde alýyor


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // JWT KONFÝGÜRASYONLARI... 

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,      // tokenýn issuer alanýný validate et
        ValidateAudience = true,    // tokenýn audience alanýný validate et
        ValidateLifetime = true,    // tokenýn lifetime alanýný validate et
        ValidateIssuerSigningKey = true,    // doðru kiþi tarafýndan imzalanýp imzalanmadýðýný yani security keyimiz ile imzalanýp imzalanmadýðý kontrolü
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)       // appsettings.Development'ta bulunduracaðýmýz security key ile imzalanmýþ bir anahtar. genellikle bu security keyler 256bit olarak yazýlýr ve sýklýkla deðiþtirilir (key generator siteleri kullanýlabilir) Amacýmýz ele geçirilmesi ve çözümlenmesini zorlaþtýrmak.
        
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
