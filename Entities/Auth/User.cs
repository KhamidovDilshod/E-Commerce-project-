using Microsoft.AspNetCore.Identity;

#pragma warning disable

namespace E_Commerce.Api.Entities.Auth;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Custom { get; init; } = String.Empty;
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHashed { get; set; }
}