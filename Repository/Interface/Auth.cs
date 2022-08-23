using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;

namespace E_Commerce.Api.Repository.Interface;

public interface IAuth
{ 
    LoginDto Login(Login login);
    Task<User?> Register(Register register);
}