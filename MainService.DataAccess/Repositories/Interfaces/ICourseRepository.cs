using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Models;
using MainService.Models.Course;

namespace MainService.DataAccess.Repositories.Interfaces;

public interface ICourseRepository
{
    ITransaction BeginTransaction();
    Task<bool> IsCourseTypeExistsById(Guid id);
    Task<Guid> CreateCourseType(DbCourseType courseType);
    Task<DbCourseType> GetCourseType(Guid id);
    Task<List<DbCourseType>> GetCourseTypes();
    Task UpdateCourseType(DbCourseType courseType);
    Task DeleteCourseType(Guid id);
    Task<bool> IsCourseExistsById(Guid id);
    Task<Guid> CreateCourse(DbCourse course);
    Task<DbCourse> GetCourse(Guid id);
    Task<List<DbCourse>> GetCourses();
    Task UpdateCourse(UpdateCourseRequest request);
    Task DeleteCourse(Guid id);
}