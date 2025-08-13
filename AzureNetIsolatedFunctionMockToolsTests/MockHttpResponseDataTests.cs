using AzureNetIsolatedFunctionMockTools;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Text;

namespace AzureNetIsolatedFunctionMockToolsTests
{
    internal class MockHttpResponseDataTests
    {
        [Test]
        public void MockHttpResponseData_DefaultConstructorWithoutParameters_ReturnsDefaultHttpResponseDataObject()
        {
            // Arrange
            MockFunctionContext mockFunctionContext = new();

            // Act
            MockHttpResponseData mockHttpResponseData = new(mockFunctionContext);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mockHttpResponseData, Is.Not.Null);
                Assert.That(mockHttpResponseData.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(mockHttpResponseData.Headers, Is.Not.Null);
                Assert.That(mockHttpResponseData.Body, Is.Not.Null);
                Assert.That(mockHttpResponseData.Cookies, Is.Not.Null);
            });
        }

        [Test]
        public void MockHttpResponseData_DefaultConstructorWithCustomParameters_ReturnsHttpResponseDataObject()
        {
            // Arrange
            MockFunctionContext mockFunctionContext = new();
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            Dictionary<string, string> mockHeaderCollection = new()
            {
                { "Content-Type", "application/json" },
                { "Custom-Header", "CustomValue" }
            };
            HttpHeadersCollection mockHeaders = new (mockHeaderCollection);
            Stream body = new MemoryStream(Encoding.UTF8.GetBytes("foo"));

            // Act
            MockHttpResponseData mockHttpResponseData = new(mockFunctionContext, statusCode, mockHeaders, body);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mockHttpResponseData, Is.Not.Null);
                Assert.That(mockHttpResponseData.StatusCode, Is.EqualTo(statusCode));
                Assert.That(mockHttpResponseData.Headers, Is.EqualTo(mockHeaders));
                Assert.That(mockHttpResponseData.Body, Is.EqualTo(body));
            });
        }
    }
}
