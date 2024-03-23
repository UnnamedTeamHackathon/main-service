using MainService.Models.Auth;

namespace MainService.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> Register(RegisterModel registerModel);
    Task<AuthResponse> Login(LoginModel loginModel);
}