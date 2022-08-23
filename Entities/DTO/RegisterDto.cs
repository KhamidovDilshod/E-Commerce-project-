namespace E_Commerce.Api.Entities.DTO;

public class RegisterDto
{
    public RegisterDto(string token, string phoneNumber)
    {
        Token = token;
        PhoneNumber = phoneNumber;
    }

    public string Token { get; set; }
    public string PhoneNumber { get; set; }
}