using MainService.Models.Course;

namespace MainService.Services.Interfaces;

public interface ICourseService
{
    Task<Guid> CreateCourseType(CreateCourseTypeRequest request);
    Task<CourseType> GetCourseType(Guid id);
    Task<List<CourseType>> GetCourseTypes();
    Task UpdateCourseType(Guid id, UpdateCourseTypeRequest request);
    Task DeleteCourseType(Guid id);
    Task<Guid> CreateCourse(CreateCourseRequest request);
    Task<Course> GetCourse(Guid id);
    Task<List<Course>> GetCourses();
    Task UpdateCourse(Guid id, UpdateCourseRequest request);
    Task DeleteCourse(Guid id);
}