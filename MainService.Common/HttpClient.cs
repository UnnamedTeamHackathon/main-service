using System.Net.Http.Headers;
using System.Text.Json;
using MainService.Common.Interfaces;
using MainService.Common.Models;

namespace MainService.Common;

public class HttpClient<TSettings> : IHttpClient<TSettings> where TSettings : IHttpClientSettings
{
    private readonly HttpClient httpClient;

    public HttpClient(IHttpClientSettings settings)
    {
        var handler = new HttpClientHandler();

        httpClient = new HttpClient(handler);
        httpClient.Timeout = settings.Timeout;
        settings.DefaultHeaders?.Invoke(httpClient.DefaultRequestHeaders);
    }

    public async Task<Response<TOutput>> Get<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default) =>
        await Send<TInput, TOutput>(uri, HttpMethod.Get, data, headerApplier);

    public async Task<Response<TOutput>> Get<TOutput>(string uri, HeaderApplier headerApplier = default) =>
        await Send<None, TOutput>(uri, HttpMethod.Get, null, headerApplier);

    public async Task<Response> Get(string uri, HeaderApplier headerApplier = default) =>
        await Send<None, None>(uri, HttpMethod.Get, null, headerApplier);

    public async Task<Response<TOutput>> Post<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default) =>
        await Send<TInput, TOutput>(uri, HttpMethod.Post, data, headerApplier);

    public async Task<Response> Post<TInput>(string uri, TInput data, HeaderApplier headerApplier = default) =>
        await Send<TInput, None>(uri, HttpMethod.Post, data, headerApplier);

    public async Task<Response> Post(string uri, HeaderApplier headerApplier = default) =>
        await Send<None, None>(uri, HttpMethod.Post, null, headerApplier);

    public async Task<Response<TOutput>> Put<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default) =>
        await Send<TInput, TOutput>(uri, HttpMethod.Put, data, headerApplier);

    public async Task<Response> Put<TInput>(string uri, TInput data = default, HeaderApplier headerApplier = default) =>
        await Send<TInput, None>(uri, HttpMethod.Put, data, headerApplier);

    public async Task<Response> Put(string uri, HeaderApplier headerApplier = default) =>
        await Send<None, None>(uri, HttpMethod.Put, null, headerApplier);

    public async Task<Response<TOutput>> Patch<TInput, TOutput>(string uri, TInput data, HeaderApplier headerApplier = default) =>
        await Send<TInput, TOutput>(uri, HttpMethod.Patch, data, headerApplier);

    public async Task<Response> Patch<TInput>(string uri, TInput data = default, HeaderApplier headerApplier = default) =>
        await Send<TInput, None>(uri, HttpMethod.Patch, data, headerApplier);

    public async Task<Response> Patch(string uri, HeaderApplier headerApplier = default) =>
        await Send<None, None>(uri, HttpMethod.Patch, null, headerApplier);

    public async Task<Response<TOutput>> Delete<TOutput>(string uri, HeaderApplier headerApplier = default) =>
        await Send<None, TOutput>(uri, HttpMethod.Delete, null, headerApplier);

    public async Task<Response> Delete(string uri, HeaderApplier headerApplier = default) =>
        await Send<None, None>(uri, HttpMethod.Delete, null, headerApplier);

    public async Task<Response<TOutput>> Send<TInput, TOutput>(string uri, HttpMethod method, TInput data, HeaderApplier headerApplier = default) =>
        await Send<TInput, TOutput>(new Request<TInput>
        {
            Uri = uri,
            Method = method,
            Data = data,
            HeadersApplier = headerApplier
        });


    public virtual async Task<Response<TOutput>> Send<TInput, TOutput>(Request<TInput> request)
    {
        var response = await Execute<TInput, TOutput>(request);

        return await Execute<TInput, TOutput>(new Request<TInput>
        {
            Uri = response.Headers.Location?.ToString(),
            Method = request.Method,
            Data = request.Data,
            RawData = request.RawData,
            HeadersApplier = request.HeadersApplier
        });
    }

    protected async Task<Response<TOutput>> Execute<TInput, TOutput>(Request<TInput> request)
    {
        using var httpRequest = new HttpRequestMessage(request.Method, new Uri(request.Uri));
        if (request.Data != null)
        {
            var content = new StringContent(JsonSerializer.Serialize(request.Data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpRequest.Content = content;
        }
        else if (request.RawData != null)
        {
            httpRequest.Content = new ByteArrayContent(request.RawData);
        }

        request.HeadersApplier?.Invoke(httpRequest.Headers, httpRequest.Content?.Headers);

        using var response = await httpClient.SendAsync(httpRequest);
        var rawResponseData = Array.Empty<byte>();

        if (typeof(TOutput) != typeof(None) && response.Content.Headers.ContentLength > 0)
        {
            rawResponseData = await response.Content.ReadAsByteArrayAsync();
        }

        return new Response<TOutput>
        {
            Status = response.StatusCode,
            RawData = rawResponseData,
            Headers = response.Headers,
            ContentHeaders = response.Content.Headers
        };
    }
}