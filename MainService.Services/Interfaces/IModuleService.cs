using MainService.Models.Module;

namespace MainService.Services.Interfaces;

public interface IModuleService
{
    Task<Guid> CreateModule(CreateModuleRequest request);
    Task<Module> GetModule(Guid id);
    Task<List<Module>> GetModulesByCourse(Guid courseId);
    Task UpdateModule(Guid id, UpdateModuleRequest request);
    Task DeleteModule(Guid id);
}