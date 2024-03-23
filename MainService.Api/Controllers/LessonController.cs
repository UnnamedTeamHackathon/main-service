using MainService.Models.Lesson;
using MainService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Api.Controllers;

[Route("api/[controller]")]
public class LessonController(ILessonService lessonService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateLesson(CreateLessonRequest request)
    {
        return Ok(await lessonService.CreateLesson(request));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetLesson(Guid id)
    {
        return Ok(await lessonService.GetLesson(id));
    }

    [HttpGet("by-module/{moduleId:guid}")]
    public async Task<IActionResult> GetLessonsByModule(Guid moduleId)
    {
        return Ok(await lessonService.GetLessonsByModule(moduleId));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateLesson(Guid id, UpdateLessonRequest request)
    {
        await lessonService.UpdateLesson(id, request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLesson(Guid id)
    {
        await lessonService.DeleteLesson(id);

        return Ok();
    }
}