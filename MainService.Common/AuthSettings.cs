using MainService.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MainService.Common;

public class AuthSettings(IConfiguration configuration) : IAuthSettings
{
    public string Issuer => configuration["Auth:Issuer"];
    public string Audience => configuration["Auth:Audience"];
    public string Key => configuration["Auth:Key"];
    public int TokenExpiresAfterHours => int.Parse(configuration["Auth:TokenExpiresAfterHours"]);
}