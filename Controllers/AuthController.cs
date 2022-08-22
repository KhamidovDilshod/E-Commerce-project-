using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers;

public class AuthController : BaseController
{
    private readonly IAuth _auth;

    public AuthController(IAuth auth)
    {
        _auth = auth;
    }

    [HttpPost("auth/register")]
    public async Task<ActionResult<RegisterDto>> Register(Register register)
    {
        var result = await _auth.Register(register);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost("auth/login")]
    public async Task<ActionResult<LoginDto>> Login(Login login)
    {
        var result = await _auth.Login(login);
        return result == null ? NotFound() : Ok(result);
    }
}