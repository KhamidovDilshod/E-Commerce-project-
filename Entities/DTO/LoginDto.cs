namespace E_Commerce.Api.Entities.DTO;

public class LoginDto
{
    public LoginDto(JwtDto token, bool isAuthenticated, string? message)
    {
        Token = token;
        IsAuthenticated = isAuthenticated;
        Message = message;
    }

    public JwtDto Token { get; set; }
    public bool IsAuthenticated { get; set; }
    public string? Message { get; set; }
}