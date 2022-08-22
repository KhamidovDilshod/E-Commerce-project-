namespace E_Commerce.Api.Entities.DTO;

public class LoginDto
{
    public LoginDto(string token, bool isAuthenticated, string? message)
    {
        Token = token;
        IsAuthenticated = isAuthenticated;
        Message = message;
    }

    public string Token { get; set; }
    public bool IsAuthenticated { get; set; } = false;
    public string Message { get; set; }
}