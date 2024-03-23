using MainService.Models.Module;
using MainService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Api.Controllers;

[Route("api/[controller]")]
public class ModuleController(IModuleService moduleService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateModule(CreateModuleRequest request)
    {
        return Ok(await moduleService.CreateModule(request));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetModule(Guid id)
    {
        return Ok(await moduleService.GetModule(id));
    }

    [HttpGet("by-course/{courseId:guid}")]
    public async Task<IActionResult> GetModulesByCourse(Guid courseId)
    {
        return Ok(await moduleService.GetModulesByCourse(courseId));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateModule(Guid id, UpdateModuleRequest request)
    {
        await moduleService.UpdateModule(id, request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteModule(Guid id)
    {
        await moduleService.DeleteModule(id);

        return Ok();
    }
}