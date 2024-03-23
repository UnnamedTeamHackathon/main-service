using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Dapper.Models;
using MainService.DataAccess.Models;
using MainService.DataAccess.Repositories.Interfaces;
using MainService.DataAccess.Repositories.Scripts;
using MainService.Models.Lesson;

namespace MainService.DataAccess.Repositories;

public class LessonRepository(IDapperContext<IDapperSettings> dapperContext) : ILessonRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<bool> IsLessonExistsById(Guid id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsLessonExistsById, new { id }));
    }

    public async Task<Guid> CreateLesson(CreateLessonRequest request, ITransaction transaction = null)
    {
        return await dapperContext.CommandWithResponse<Guid>(new QueryObject(Sql.CreateLesson, request), transaction);
    }

    public async Task<DbLesson> GetLesson(Guid id)
    {
        return await dapperContext.FirstOrDefault<DbLesson>(new QueryObject(Sql.GetLessonById, new { id }));
    }

    public async Task<List<DbLesson>> GetLessonsByModule(Guid moduleId)
    {
        return await dapperContext.ListOrEmpty<DbLesson>(new QueryObject(Sql.GetLessonsByModuleId, new { moduleId }));
    }

    public async Task UpdateLesson(UpdateLessonRequest request, ITransaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateLesson, request), transaction);
    }

    public async Task DeleteLesson(Guid id, ITransaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.DeleteLesson, new { id }), transaction);
    }

    public async Task<int> GetLastLessonOrder(Guid moduleId)
    {
        return await dapperContext.FirstOrDefault<int>(new QueryObject(Sql.GetLastLessonOrder, new { moduleId }));
    }

    public async Task ReorderLessons(Guid id, Guid moduleId, int order, int newOrder, ITransaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.ReorderLessons, new { id, moduleId, order, newOrder }), transaction);
    }
}