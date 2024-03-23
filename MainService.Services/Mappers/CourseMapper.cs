using MainService.DataAccess.Models;
using MainService.Models.Course;

namespace MainService.Services.Mappers;

public static class CourseMapper
{
    public static CourseType MapToDomain(this DbCourseType source)
    {
        return source == null
            ? default
            : new CourseType
            {
                Id = source.Id,
                Name = source.Name
            };
    }

    public static List<CourseType> MapToDomain(this List<DbCourseType> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }

    public static DbCourseType MapToDb(this CourseType source)
    {
        return source == null
            ? default
            : new DbCourseType
            {
                Id = source.Id,
                Name = source.Name
            };
    }
    
    public static DbCourseType MapToDb(this CreateCourseTypeRequest source)
    {
        return source == null
            ? default
            : new DbCourseType
            {
                Name = source.Name
            };
    }
    
    public static DbCourseType MapToDb(this UpdateCourseTypeRequest source, Guid id)
    {
        return source == null
            ? default
            : new DbCourseType
            {
                Id = id,
                Name = source.Name
            };
    }
    
    public static Course MapToDomain(this DbCourse source)
    {
        return source == null
            ? default
            : new Course
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Difficulty = (CourseDifficulty)source.Difficulty,
                TypeId = source.TypeId
            };
    }

    public static List<Course> MapToDomain(this List<DbCourse> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }

    public static DbCourse MapToDb(this Course source)
    {
        return source == null
            ? default
            : new DbCourse
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Difficulty = (int)source.Difficulty,
                TypeId = source.TypeId
            };
    }
    
    public static DbCourse MapToDb(this CreateCourseRequest source)
    {
        return source == null
            ? default
            : new DbCourse
            {
                Name = source.Name,
                Description = source.Description,
                Difficulty = (int)source.Difficulty,
                TypeId = source.TypeId
            };
    }
}