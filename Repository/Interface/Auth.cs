using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;

namespace E_Commerce.Api.Repository.Interface;

public interface IAuth
{
    Task<LoginDto>? Login(Login login);
    Task<LoginDto?> Register(Register register);
}