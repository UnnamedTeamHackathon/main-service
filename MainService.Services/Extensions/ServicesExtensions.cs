using MainService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MainService.Services.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<ICourseService, CourseService>()
            .AddScoped<IModuleService, ModuleService>()
            .AddScoped<ILessonService, LessonService>();
    }
}