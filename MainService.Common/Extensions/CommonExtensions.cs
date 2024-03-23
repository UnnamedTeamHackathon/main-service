using MainService.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MainService.Common.Extensions;

public static class CommonExtensions
{
    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
        return services
            .AddTransient<IHttpClientSettings, HttpClientSettings>()
            .AddTransient<IHttpClient<IHttpClientSettings>, HttpClient<IHttpClientSettings>>()
            .AddSingleton<IClusterSettings, ClusterSettings>()
            .AddSingleton<IHttpAuthManager, HttpAuthManager>()
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}