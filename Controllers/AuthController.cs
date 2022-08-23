using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Repository.Interface;
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
        return result == null ? NotFound("User already exist") : Ok(result);
    }

    [HttpPost("auth/login")]
    public ActionResult<LoginDto> Login(Login login)
    {
        var result =  _auth.Login(login);
        return Ok(result);
    }
}