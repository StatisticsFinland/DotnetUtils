using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using AzureNetIsolatedFunctionMockTools.Internal;

namespace AzureNetIsolatedFunctionMockTools
{
    /// <summary>
    /// Mock implementation of <see cref="HttpResponseData"/> for testing purposes. All fields apart from <see cref="FunctionContext"/> are optional and will be initialized to default values if not provided.
    /// </summary>
    /// <param name="functionContext"><see cref="FunctionContext"/> object. Recommended to use <see cref="MockFunctionContext"/> for testing.</param>
    /// <param name="statusCode"></param><see cref="HttpStatusCode">HTTP status code of the response. Default is <see cref="HttpStatusCode.OK"/>.</param>
    /// <param name="headers"><see cref="HttpHeadersCollection">Headers of the response. Default is an empty <see cref="HttpHeadersCollection"/>.</param>
    /// <param name="stream"/><see cref="Stream">Body stream of the response. Default is a new <see cref="MemoryStream"/>.</param>
    /// <param name="cookies"><see cref="HttpCookies">Cookies of the response. Default is an empty collection.</param>"
    public class MockHttpResponseData(FunctionContext functionContext, HttpStatusCode? statusCode = null, HttpHeadersCollection? headers = null, Stream? stream = null, HttpCookies? cookies = null) : HttpResponseData(functionContext)
    {
        public override HttpStatusCode StatusCode { get; set; } = statusCode ?? HttpStatusCode.OK;

        public override HttpHeadersCollection Headers { get; set; } = headers ?? [];

        public override Stream Body { get; set; } = stream ?? new MemoryStream();

        public override HttpCookies Cookies => cookies ?? new MockHttpCookies();
    }
}
