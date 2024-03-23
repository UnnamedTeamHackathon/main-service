using System.Net.Http.Headers;

namespace MainService.Common.Extensions;

public static class HttpResponseHeadersExtensions
{
    public static string GetValue(this HttpResponseHeaders headers, string name)
    {
        return headers.GetValues(name).FirstOrDefault();
    }
}