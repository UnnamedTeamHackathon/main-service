using System.Security.Claims;
using MainService.Common;
using MainService.Common.Interfaces;
using MainService.DataAccess.Models;
using MainService.DataAccess.Repositories.Interfaces;
using MainService.Models.Auth;
using MainService.Models.User;
using MainService.Services.Exceptions;
using MainService.Services.Interfaces;

namespace MainService.Services;

public class AuthService(IUserRepository userRepository, ITokenService tokenService, IAuthSettings authSettings) : IAuthService
{
    public async Task<AuthResponse> Register(RegisterModel registerModel)
    {
        if (await userRepository.IsUserExistsByUsername(registerModel.Username))
        {
            throw new UsernameAlreadyTakenException(registerModel.Username);
        }
        
        if (await userRepository.IsUserExistsByEmail(registerModel.Email))
        {
            throw new EmailAlreadyTakenException(registerModel.Email);
        }
        
        var refreshToken = tokenService.CreateToken(new List<Claim>());
        var id = await userRepository.CreateUser(new DbUser
        {
            Role = (int)Role.User,
            Email = registerModel.Email,
            Username = registerModel.Username,
            PasswordHash = Hash.GetHash(registerModel.Password),
            RefreshToken = refreshToken,
            RefreshTokenExpiredAfter = DateTime.UtcNow.AddHours(authSettings.TokenExpiresAfterHours)
        });

        var claims = Jwt.GetClaims(id, (int)Role.User, registerModel.Email, registerModel.Username);
        var accessToken = tokenService.CreateToken(claims, 24);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResponse> Login(LoginModel loginModel)
    {
        var user = await userRepository.GetUser(loginModel.Email, Hash.GetHash(loginModel.Password));
        
        if (user == null)
        {
            throw new BadCredentialsException();
        }

        var claims = Jwt.GetClaims(user.Id, user.Role, user.Email, user.Username);
        var accessToken = tokenService.CreateToken(claims, 24);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = user.RefreshToken
        };
    }
}