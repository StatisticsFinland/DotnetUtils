using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Security.Claims;

namespace AzureNetIsolatedFunctionMockTools
{
    /// <summary>
    /// Mock implementation of <see cref="HttpRequestData"/> for testing purposes. All fields apart from <see cref="FunctionContext"/> are optional and will be initialized to default values if not provided.
    /// </summary>
    /// <param name="functionContext"><see cref="FunctionContext"/> object. Recommended to use <see cref="MockFunctionContext"/> for testing.</param>
    /// <param name="body">Body stream of the request. Default is a new <see cref="MemoryStream"/>.</param>
    /// <param name="headers">Headers of the request. Default is an empty <see cref="HttpHeadersCollection"/>.</param>
    /// <param name="cookies">Cookies of the request. Default is an empty collection.</param>
    /// <param name="url">Request URL. Default is an <see cref="Uri"/> object initialized with an empty string.</param>
    /// <param name="identities"><see cref="ClaimsIdentity"/> collection representing the identities of the request. Default is an empty collection.</param>"/>
    /// <param name="method">string representing the HTTP method of the request. Default is an empty string.</param>
    /// <param name="response"><see cref="HttpResponseData"/> object. Default is a new <see cref="MockHttpResponseData"/>.</param>
    public class MockHttpRequestData(
        FunctionContext functionContext,
        Stream? body = null,
        HttpHeadersCollection? headers = null,
        IReadOnlyCollection<IHttpCookie>? cookies = null,
        Uri? url = null,
        IEnumerable<ClaimsIdentity>? identities = null,
        string? method = null,
        HttpResponseData? response = null) : HttpRequestData(functionContext)
    {
        public override Stream Body => body ?? new MemoryStream();

        public override HttpHeadersCollection Headers => headers ?? [];

        public override IReadOnlyCollection<IHttpCookie> Cookies => cookies ?? [];

        public override Uri Url => url ?? new("https://example.com");

        public override IEnumerable<ClaimsIdentity> Identities => identities ?? [];

        public override string Method => method ?? string.Empty;

        public override HttpResponseData CreateResponse()
        {
            return response ?? new MockHttpResponseData(FunctionContext);
        }
    }
}
