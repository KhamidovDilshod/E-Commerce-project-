using E_Commerce.Api.Entities.Auth;

namespace E_Commerce.Api.Repository.Interface;

public interface IToken
{
    string CreateToken(JwtRole jwt);
}