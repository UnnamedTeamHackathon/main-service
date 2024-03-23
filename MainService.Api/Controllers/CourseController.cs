using MainService.Models.Course;
using MainService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Api.Controllers;

[Route("api/[controller]")]
public class CourseController(ICourseService courseService) : BaseController
{
    [HttpPost("type")]
    public async Task<IActionResult> CreateCourseType(CreateCourseTypeRequest request)
    {
        return Ok(await courseService.CreateCourseType(request));
    }

    [HttpGet("type/{id:guid}")]
    public async Task<IActionResult> GetCourseType(Guid id)
    {
        return Ok(await courseService.GetCourseType(id));
    }

    [HttpGet("type")]
    public async Task<IActionResult> GetCourseTypes()
    {
        return Ok(await courseService.GetCourseTypes());
    }

    [HttpPut("type/{id:guid}")]
    public async Task<IActionResult> UpdateCourseType(Guid id, UpdateCourseTypeRequest request)
    {
        await courseService.UpdateCourseType(id, request);

        return Ok();
    }

    [HttpDelete("type/{id:guid}")]
    public async Task<IActionResult> DeleteCourseType(Guid id)
    {
        await courseService.DeleteCourseType(id);

        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
    {
        return Ok(await courseService.CreateCourse(request));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCourse(Guid id)
    {
        return Ok(await courseService.GetCourse(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        return Ok(await courseService.GetCourses());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCourse(Guid id, UpdateCourseRequest request)
    {
        await courseService.UpdateCourse(id, request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        await courseService.DeleteCourse(id);

        return Ok();
    }
}