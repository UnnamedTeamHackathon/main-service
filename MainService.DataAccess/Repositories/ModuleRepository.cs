using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Dapper.Models;
using MainService.DataAccess.Models;
using MainService.DataAccess.Repositories.Interfaces;
using MainService.DataAccess.Repositories.Scripts;

namespace MainService.DataAccess.Repositories;

public class ModuleRepository(IDapperContext<IDapperSettings> dapperContext) : IModuleRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<bool> IsModuleExistsById(Guid id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsModuleExistsById, new { id }));
    }

    public async Task<Guid> CreateModule(DbModule module, ITransaction transaction = null)
    {
        return await dapperContext.CommandWithResponse<Guid>(new QueryObject(Sql.CreateModule, module), transaction);
    }

    public async Task<DbModule> GetModule(Guid id)
    {
        return await dapperContext.FirstOrDefault<DbModule>(new QueryObject(Sql.GetModuleById, new { id }));
    }

    public async Task<List<DbModule>> GetModulesByCourse(Guid courseId)
    {
        return await dapperContext.ListOrEmpty<DbModule>(new QueryObject(Sql.GetModulesByCourseId, new { courseId }));
    }

    public async Task UpdateModule(Guid id, string name, ITransaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateModule, new { id, name }), transaction);
    }

    public async Task DeleteModule(Guid id, ITransaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.DeleteModule, new { id }), transaction);
    }

    public async Task<int> GetLastModuleOrder(Guid courseId)
    {
        return await dapperContext.FirstOrDefault<int>(new QueryObject(Sql.GetLastModuleOrder, new { courseId }));
    }

    public async Task ReorderModules(Guid id, Guid courseId, int order, int newOrder, ITransaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.ReorderModules, new { id, courseId, order, newOrder }), transaction);
    }
}