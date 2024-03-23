using System.Net.Http.Headers;

namespace MainService.Common;

public delegate void HeaderApplier(HttpRequestHeaders requestHeaders, HttpContentHeaders contentHeaders);