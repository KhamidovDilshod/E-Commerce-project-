using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;

namespace E_Commerce.Api.Repository.Interface;

public interface IToken
{
    JwtDto CreateToken(User user);
}