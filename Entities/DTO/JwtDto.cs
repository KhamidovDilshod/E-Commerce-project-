namespace E_Commerce.Api.Entities.DTO;
#pragma warning disable
public class JwtDto
{
    public JwtDto(string token, DateTime expiresAt)
    {
        ExpiresAt = expiresAt;
        Token = token;
    }

    public string Token { get;set; }
    public DateTime ExpiresAt { get; set;}
}