using MainService.Common;
using MainService.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Api.Controllers;

[Authorize]
[ApiController]
public class BaseController : ControllerBase
{
    private string AuthHeader => HttpContext.Request.Headers.Authorization.ToString();

    protected Guid Id => Guid.Parse(Jwt.GetId(AuthHeader));
    protected Role Role => Enum.Parse<Role>(Jwt.GetRole(AuthHeader));
    protected string Email => Jwt.GetEmail(AuthHeader);
    protected string Username => Jwt.GetUsername(AuthHeader);
}