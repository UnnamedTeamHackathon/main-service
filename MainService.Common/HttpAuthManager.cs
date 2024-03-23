using System.Net.Http.Headers;
using MainService.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MainService.Common;

public class HttpAuthManager(IHttpContextAccessor httpContextAccessor) : IHttpAuthManager
{
    private const string DefaultToken = "token";
    
    public HeaderApplier GetAuthHeaders(string token = null)
    {
        return (request, _) =>
        {
            var auth = token ?? httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            request.Authorization = AuthenticationHeaderValue.Parse(string.IsNullOrEmpty(auth) ? DefaultToken : auth);
        };
    }
}