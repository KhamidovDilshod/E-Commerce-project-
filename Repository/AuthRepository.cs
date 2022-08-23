using System.Security.Cryptography;
using System.Text;
using E_Commerce.Api.Entities;
using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Repository.Interface;

#pragma warning disable

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

    public  LoginDto Login(Login login)
    {
        var result = FindUser(login.PhoneNumber);
        var user = result[0];
        if (result.Count != 1) return new LoginDto(null, false, "User Not found");
        return VerifyPassword(login.Password, user.PasswordHashed, user.PasswordSalt)
            ? new LoginDto(_token.CreateToken(user), true, "Logged in")
            : new LoginDto(null, true, "Bad credentials");
    }

    public async Task<User?> Register(Register register)
    {
        var isExists = FindUser(register.PhoneNumber);
        switch (isExists.Count)
        {
            case > 0:
                return null;
            case 0:
            {
                Encoder(register.Password, out var passwordHash, out var passwordSalt);
                var user = new User
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    PhoneNumber = register.PhoneNumber,
                    Email = register.EmailAddress,
                    UserName = register.UserName,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHashed = passwordHash,
                    PasswordSalt = passwordSalt,
                    NormalizedUserName = register.Role
                };
                var res = (await _context.Users.AddAsync(user)).Entity;
                await _context.SaveChangesAsync();
                res.PasswordSalt = null;
                res.PasswordHashed = null;
                return res;
            }
            default: return null;
        }
    }

    private List<User> FindUser(string phoneNumber)
    {
        var result = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        return result is null ? new List<User>() : new List<User> {result};
    }

    private void Encoder(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        passwordSalt = hmac.Key;
    }

    private bool VerifyPassword(string password, IEnumerable<byte> passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}