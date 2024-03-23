namespace MainService.Common.Interfaces;

public interface IHttpAuthManager
{
    HeaderApplier GetAuthHeaders(string token = null);
}