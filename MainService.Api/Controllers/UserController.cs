using System.ComponentModel.DataAnnotations;
using MainService.Models.User;
using MainService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Api.Controllers;

[Route("api/[controller]")]
public class UserController(IUserService userService) : BaseController
{
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        return Ok(await userService.GetUser(Id));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        return Ok(await userService.GetUser(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await userService.GetUsers());
    }

    [HttpPut("me")]
    public async Task<IActionResult> UpdateMe(UpdateUserRequest request)
    {
        request.Id = Id;
        await userService.UpdateUser(request);

        return Ok();
    }

    [HttpDelete("me")]
    public async Task<IActionResult> DeleteMe()
    {
        await userService.DeleteUser(Id);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        if (Role != Role.Admin)
        {
            return Forbid();
        }

        await userService.DeleteUser(id);

        return Ok();
    }

    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        request.Email = Email;
        await userService.ChangePassword(request);

        return Ok();
    }

    [HttpPut("{id:guid}/role")]
    public async Task<IActionResult> ChangeRole(Guid id, [Required] Role role)
    {
        if (Role != Role.Admin)
        {
            return Forbid();
        }

        await userService.ChangeRole(id, role);
        
        return Ok();
    }
}