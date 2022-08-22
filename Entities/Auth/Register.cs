namespace E_Commerce.Api.Entities.Auth;

#pragma warning disable

public class Register
{
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}