using MainService.DataAccess.Repositories.Interfaces;
using MainService.Models.Module;
using MainService.Services.Exceptions;
using MainService.Services.Interfaces;
using MainService.Services.Mappers;

namespace MainService.Services;

public class ModuleService(IModuleRepository moduleRepository, ICourseRepository courseRepository) : IModuleService
{
    public async Task<Guid> CreateModule(CreateModuleRequest request)
    {
        if (!await courseRepository.IsCourseExistsById(request.CourseId))
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        var lastOrder = await moduleRepository.GetLastModuleOrder(request.CourseId);
        request.Order = lastOrder + 1;

        return await moduleRepository.CreateModule(request.MapToDb());
    }

    public async Task<Module> GetModule(Guid id)
    {
        var module = await moduleRepository.GetModule(id);
        if (module == null)
        {
            throw new ModuleNotFoundException(id);
        }

        return module.MapToDomain();
    }

    public async Task<List<Module>> GetModulesByCourse(Guid courseId)
    {
        var modules = await moduleRepository.GetModulesByCourse(courseId);

        return modules.MapToDomain();
    }

    public async Task UpdateModule(Guid id, UpdateModuleRequest request)
    {
        var module = await moduleRepository.GetModule(id);
        if (module == null)
        {
            throw new ModuleNotFoundException(id);
        }

        using var transaction = moduleRepository.BeginTransaction();
        try
        {
            await moduleRepository.UpdateModule(id, request.Name, transaction);

            if (request.Order.HasValue)
            {
                await moduleRepository.ReorderModules(id, module.CourseId, module.Order, request.Order.Value, transaction);
            }
            
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task DeleteModule(Guid id)
    {
        var module = await moduleRepository.GetModule(id);
        if (module == null)
        {
            throw new ModuleNotFoundException(id);
        }

        using var transaction = moduleRepository.BeginTransaction();
        try
        {
            var lastOrder = await moduleRepository.GetLastModuleOrder(module.CourseId);
            await moduleRepository.ReorderModules(id, module.CourseId, module.Order, lastOrder + 1, transaction);
            await moduleRepository.DeleteModule(id, transaction);
            
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}