namespace E_Commerce.Api.Entities.Auth;

public class User
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public Purchased? Purchased { get; set; } = null;
    public string Role { get; set; }
}