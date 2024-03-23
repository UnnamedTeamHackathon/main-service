using MainService.DataAccess.Models;
using MainService.Models.Module;

namespace MainService.Services.Mappers;

public static class ModuleMapper
{
    public static Module MapToDomain(this DbModule source)
    {
        return source == null
            ? default
            : new Module
            {
                Id = source.Id,
                CourseId = source.CourseId,
                Name = source.Name,
                Order = source.Order
            };
    }

    public static List<Module> MapToDomain(this List<DbModule> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }

    public static DbModule MapToDb(this Module source)
    {
        return source == null
            ? default
            : new DbModule
            {
                Id = source.Id,
                CourseId = source.CourseId,
                Name = source.Name,
                Order = source.Order
            };
    }
    
    public static DbModule MapToDb(this CreateModuleRequest source)
    {
        return source == null
            ? default
            : new DbModule
            {
                CourseId = source.CourseId,
                Name = source.Name,
                Order = source.Order
            };
    }
}