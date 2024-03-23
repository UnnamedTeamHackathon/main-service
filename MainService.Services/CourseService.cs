using MainService.DataAccess.Repositories.Interfaces;
using MainService.Models.Course;
using MainService.Services.Exceptions;
using MainService.Services.Interfaces;
using MainService.Services.Mappers;

namespace MainService.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public async Task<Guid> CreateCourseType(CreateCourseTypeRequest request)
    {
        return await courseRepository.CreateCourseType(request.MapToDb());
    }

    public async Task<CourseType> GetCourseType(Guid id)
    {
        var courseType = await courseRepository.GetCourseType(id);
        if (courseType == null)
        {
            throw new CourseTypeNotFoundException(id);
        }

        return courseType.MapToDomain();
    }

    public async Task<List<CourseType>> GetCourseTypes()
    {
        var courseTypes = await courseRepository.GetCourseTypes();

        return courseTypes.MapToDomain();
    }

    public async Task UpdateCourseType(Guid id, UpdateCourseTypeRequest request)
    {
        if (!await courseRepository.IsCourseTypeExistsById(id))
        {
            throw new CourseTypeNotFoundException(id);
        }

        await courseRepository.UpdateCourseType(request.MapToDb(id));
    }

    public async Task DeleteCourseType(Guid id)
    {
        if (!await courseRepository.IsCourseTypeExistsById(id))
        {
            throw new CourseTypeNotFoundException(id);
        }

        await courseRepository.DeleteCourseType(id);
    }

    public async Task<Guid> CreateCourse(CreateCourseRequest request)
    {
        if (!await courseRepository.IsCourseTypeExistsById(request.TypeId))
        {
            throw new CourseTypeNotFoundException(request.TypeId);
        }
        
        return await courseRepository.CreateCourse(request.MapToDb());
    }

    public async Task<Course> GetCourse(Guid id)
    {
        var course = await courseRepository.GetCourse(id);
        if (course == null)
        {
            throw new CourseNotFoundException(id);
        }

        return course.MapToDomain();
    }

    public async Task<List<Course>> GetCourses()
    {
        var courses = await courseRepository.GetCourses();

        return courses.MapToDomain();
    }

    public async Task UpdateCourse(Guid id, UpdateCourseRequest request)
    {
        if (!await courseRepository.IsCourseExistsById(id))
        {
            throw new CourseNotFoundException(id);
        }
        
        if (request.TypeId != null && !await courseRepository.IsCourseTypeExistsById(request.TypeId.Value))
        {
            throw new CourseTypeNotFoundException(request.TypeId.Value);
        }

        request.Id = id;
        await courseRepository.UpdateCourse(request);
    }

    public async Task DeleteCourse(Guid id)
    {
        if (!await courseRepository.IsCourseExistsById(id))
        {
            throw new CourseNotFoundException(id);
        }

        await courseRepository.DeleteCourse(id);
    }
}