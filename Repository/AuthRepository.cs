using System.Security.Cryptography;
using System.Text;
using E_Commerce.Api.Entities;
using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Api.Repository;

public class AuthRepository : IAuth
{
    private readonly DataContext _context;
    private readonly IToken _token;

    public AuthRepository(DataContext context, IToken token)
    {
        _context = context;
        _token = token;
    }

    public async Task<LoginDto>? Login(Login login)
    {
        var result = await FindUser(login.PhoneNumber);
        if (result != null && result.Role == login.Role.ToString())
        {
            var hmac = new HMACSHA512(result.PasswordSalt);
            var role = new JwtRole
            {
                Role = login.Role.ToString(),
                PhoneNumber = login.PhoneNumber
            };
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != result.PasswordHash[i]) return null;
                return new LoginDto(_token.CreateToken(role), true, "Logged In");
            }
        }

        return null;
    }

    public async Task<LoginDto?> Register(Register register)
    {
        var result = await FindUser(register.PhoneNumber);
        if (result == null)
        {
            var role = new JwtRole
            {
                Role = register.Role.ToString(),
                PhoneNumber = register.PhoneNumber
            };
            var hmac = new HMACSHA512();
            var user = new User
            {
                PhoneNumber = register.PhoneNumber,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                PasswordSalt = hmac.Key,
                Role = register.Role
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new LoginDto(_token.CreateToken(role), true, "User registered");
        }

        return null;
    }

    private async Task<User> FindUser(string phoneNumber)
    {
        var result = await _context.Users.Where(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        return result;
    }
}