using System.Security.Claims;
using MainService.Models.Auth;

namespace MainService.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(IEnumerable<Claim> claims, int tokenExpiresAfterHours = 0);
    Task<AuthResponse> RefreshToken(string refreshToken);
}