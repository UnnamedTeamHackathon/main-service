using MainService.Models.Auth;
using MainService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService, ITokenService tokenService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        return Ok(await authService.Register(registerModel));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        return Ok(await authService.Login(loginModel));
    }
    
    [HttpPut("refresh-token/{token}")]
    public async Task<IActionResult> RefreshToken(string token)
    {
        return Ok(await tokenService.RefreshToken(token));
    }
}