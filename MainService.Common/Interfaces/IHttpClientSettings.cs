using System.Net.Http.Headers;

namespace MainService.Common.Interfaces;

public interface IHttpClientSettings
{
    public TimeSpan Timeout { get; }
    public string BaseAddress { get; }
    public Action<HttpRequestHeaders> DefaultHeaders { get; }
}