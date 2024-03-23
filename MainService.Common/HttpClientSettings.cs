using System.Net.Http.Headers;
using MainService.Common.Interfaces;

namespace MainService.Common;

public class HttpClientSettings : IHttpClientSettings
{
    public TimeSpan Timeout => TimeSpan.FromSeconds(15);
    public string BaseAddress => string.Empty;
    public Action<HttpRequestHeaders> DefaultHeaders { get; }
}