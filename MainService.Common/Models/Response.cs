using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MainService.Common.Models;

public class Response
{
    public HttpStatusCode Status { get; set; }
    public HttpResponseHeaders Headers { get; set; }
    public HttpContentHeaders ContentHeaders { get; set; }
}

public class Response<TOutput> : Response
{
    public byte[] RawData { get; set; }
    public string TextData => Encoding.UTF8.GetString(RawData);
    public TOutput Result => JsonSerializer.Deserialize<TOutput>(TextData);
}