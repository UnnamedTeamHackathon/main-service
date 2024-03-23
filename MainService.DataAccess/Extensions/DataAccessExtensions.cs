using System.Reflection;
using DbUp;
using MainService.DataAccess.Dapper;
using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Models.Settings;
using MainService.DataAccess.Repositories;
using MainService.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MainService.DataAccess.Extensions;

public static class DataAccessExtensions
{
    public static IServiceCollection MigrateDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["MainServiceDatabase:ConnectionString"];
        
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .WithTransaction()
            .WithVariablesDisabled()
            .LogToConsole()
            .Build();

        if (upgrader.IsUpgradeRequired())
        {
            upgrader.PerformUpgrade();
        }

        return services;
    }
    
    public static IServiceCollection AddDapper(this IServiceCollection services)
    {
        return services
            .AddSingleton<IDapperSettings, MainServiceDatabase>()
            .AddSingleton<IDapperContext<IDapperSettings>, DapperContext<IDapperSettings>>();
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICourseRepository, CourseRepository>()
            .AddScoped<IModuleRepository, ModuleRepository>()
            .AddScoped<ILessonRepository, LessonRepository>();
    }
}