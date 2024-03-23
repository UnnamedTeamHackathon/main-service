using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Dapper.Models;
using MainService.DataAccess.Models;
using MainService.DataAccess.Repositories.Interfaces;
using MainService.DataAccess.Repositories.Scripts;
using MainService.Models.Course;

namespace MainService.DataAccess.Repositories;

public class CourseRepository(IDapperContext<IDapperSettings> dapperContext) : ICourseRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<bool> IsCourseTypeExistsById(Guid id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsCourseTypeExistsById, new { id }));
    }

    public async Task<Guid> CreateCourseType(DbCourseType courseType)
    {
        return await dapperContext.CommandWithResponse<Guid>(new QueryObject(Sql.CreateCourseType, courseType));
    }

    public async Task<DbCourseType> GetCourseType(Guid id)
    {
        return await dapperContext.FirstOrDefault<DbCourseType>(new QueryObject(Sql.GetCourseTypeById, new { id }));
    }

    public async Task<List<DbCourseType>> GetCourseTypes()
    {
        return await dapperContext.ListOrEmpty<DbCourseType>(new QueryObject(Sql.GetCourseTypes));
    }

    public async Task UpdateCourseType(DbCourseType courseType)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateCourseType, courseType));
    }

    public async Task DeleteCourseType(Guid id)
    {
        await dapperContext.Command(new QueryObject(Sql.DeleteCourseType, new { id }));
    }

    public async Task<bool> IsCourseExistsById(Guid id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsCourseExistsById, new { id }));
    }

    public async Task<Guid> CreateCourse(DbCourse course)
    {
        return await dapperContext.CommandWithResponse<Guid>(new QueryObject(Sql.CreateCourse, course));
    }

    public async Task<DbCourse> GetCourse(Guid id)
    {
        return await dapperContext.FirstOrDefault<DbCourse>(new QueryObject(Sql.GetCourseById, new { id }));
    }

    public async Task<List<DbCourse>> GetCourses()
    {
        return await dapperContext.ListOrEmpty<DbCourse>(new QueryObject(Sql.GetCourses));
    }

    public async Task UpdateCourse(UpdateCourseRequest request)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateCourse, request));
    }

    public async Task DeleteCourse(Guid id)
    {
        await dapperContext.Command(new QueryObject(Sql.DeleteCourse, new { id }));
    }
}