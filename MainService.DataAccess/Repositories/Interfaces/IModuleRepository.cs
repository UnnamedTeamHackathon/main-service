using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Models;

namespace MainService.DataAccess.Repositories.Interfaces;

public interface IModuleRepository
{
    ITransaction BeginTransaction();
    Task<bool> IsModuleExistsById(Guid id);
    Task<Guid> CreateModule(DbModule module, ITransaction transaction = null);
    Task<DbModule> GetModule(Guid id);
    Task<List<DbModule>> GetModulesByCourse(Guid courseId);
    Task UpdateModule(Guid id, string name, ITransaction transaction = null);
    Task DeleteModule(Guid id, ITransaction transaction = null);
    Task<int> GetLastModuleOrder(Guid courseId);
    Task ReorderModules(Guid id, Guid courseId, int order, int newOrder, ITransaction transaction = null);
}