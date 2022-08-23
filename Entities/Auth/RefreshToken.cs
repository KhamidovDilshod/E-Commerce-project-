using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable
namespace E_Commerce.Api.Entities.Auth;

public class RefreshToken
{
    [Key] public int Id { get; set; }

    public string Token { get; set; }
    public string JwtId { get; set; }
    public string IsRevoked { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateExpire { get; set; }
    public string Userid { get; set; }
    [ForeignKey(nameof(Userid))] public User User { get; set; }
}