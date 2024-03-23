namespace MainService.Common.Models;

public class Request<TInput>
{
    public string Uri { get; set; }
    public HttpMethod Method { get; set; }
    public HeaderApplier HeadersApplier { get; set; }
    public byte[] RawData { get; set; }
    public TInput Data { get; set; }
}