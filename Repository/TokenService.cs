using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce.Api.Repository;

public class TokenService : IToken
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public JwtDto CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.NameId, user.PhoneNumber),
            new(JwtRegisteredClaimNames.Sub, user.NormalizedUserName),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var authSigningKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("AppSettings:Secret")));
        var token = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
            audience: _configuration.GetValue<string>("AppSettings:Audience"),
            expires: DateTime.UtcNow.AddDays(1),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return new JwtDto(jwtToken, token.ValidTo);
    }
}