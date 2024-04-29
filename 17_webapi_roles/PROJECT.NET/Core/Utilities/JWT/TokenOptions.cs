namespace Core.Utilities.JWT;

public class TokenOptions       // appsettings.Development.json dosyamızdaki alanları buraya yazdık ve bu sayede Program.cs' de bu alanları get edebiliriz.
{
    public string SecurityKey { get; set; }
    public int ExpirationTime { get; set; }
    public int RefreshTokenTTL { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
