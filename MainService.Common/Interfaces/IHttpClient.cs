using MainService.Common.Models;

namespace MainService.Common.Interfaces;

public interface IHttpClient<TSettings> where TSettings : IHttpClientSettings
{
    public Task<Response<TOutput>> Get<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default);
    public Task<Response<TOutput>> Get<TOutput>(string uri, HeaderApplier headerApplier = default);
    public Task<Response> Get(string uri, HeaderApplier headerApplier = default);

    public Task<Response<TOutput>> Post<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default);
    public Task<Response> Post<TInput>(string uri, TInput data, HeaderApplier headerApplier = default);
    public Task<Response> Post(string uri, HeaderApplier headerApplier = default);
        
    public Task<Response<TOutput>> Put<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default);
    public Task<Response> Put<TInput>(string uri, TInput data, HeaderApplier headerApplier = default);
    public Task<Response> Put(string uri, HeaderApplier headerApplier = default);
        
    public Task<Response<TOutput>> Patch<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default);
    public Task<Response> Patch<TInput>(string uri, TInput data, HeaderApplier headerApplier = default);
    public Task<Response> Patch(string uri, HeaderApplier headerApplier = default);
        
    public Task<Response<TOutput>> Delete<TOutput>(string uri, HeaderApplier headerApplier = default);
    public Task<Response> Delete(string uri, HeaderApplier headerApplier = default);

    public Task<Response<TOutput>> Send<TInput, TOutput>(string uri, HttpMethod method, TInput data, HeaderApplier headerApplier = default);
    public Task<Response<TOutput>> Send<TInput, TOutput>(Request<TInput> request);
}