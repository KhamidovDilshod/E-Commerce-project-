using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Entities.Auth;

#pragma warning disable

public class Register
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    [Required] public string Password { get; set; }
    public string Role { get; set; }
}