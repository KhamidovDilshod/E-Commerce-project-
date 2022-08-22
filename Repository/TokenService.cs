using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Repository.Interface;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce.Api.Repository;

public class TokenService : IToken
{
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Token")));
    }

    public string CreateToken(JwtRole jwt)
    {
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.NameId,jwt.PhoneNumber ),
            new(JwtRegisteredClaimNames.NameId,jwt.Role )
        };
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}