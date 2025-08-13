using AzureNetIsolatedFunctionMockTools;
using Microsoft.Azure.Functions.Worker.Http;
using System.Security.Claims;
using System.Text;

namespace AzureNetIsolatedFunctionMockToolsTests
{
    internal class MockHttpRequestDataTests
    {
        [Test]
        public void MockHttpRequestData_DefaultConstructorWithoutParameters_ReturnsDefaultHttpRequestDataObject()
        {
            // Arrange
            MockFunctionContext mockFunctionContext = new();

            // Act
            MockHttpRequestData mockHttpRequestData = new(mockFunctionContext);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mockHttpRequestData, Is.Not.Null);
                Assert.That(mockHttpRequestData.Body, Is.Not.Null);
                Assert.That(mockHttpRequestData.Headers, Is.Not.Null);
                Assert.That(mockHttpRequestData.Cookies, Is.Not.Null);
                Assert.That(mockHttpRequestData.Identities, Is.Not.Null);
                Assert.That(mockHttpRequestData.Method, Is.Not.Null);
                Assert.That(mockHttpRequestData.Url, Is.Not.Null);
                Assert.That(mockHttpRequestData.FunctionContext, Is.EqualTo(mockFunctionContext));
                Assert.That(mockHttpRequestData.CreateResponse(), Is.Not.Null);
            });
        }

        [Test]
        public void MockHttpRequestData_DefaultConstructorWithCustomParameters_ReturnsHttpRequestDataObject()
        {
            // Arrange
            MockFunctionContext mockFunctionContext = new();
            Stream mockBody = new MemoryStream(Encoding.UTF8.GetBytes("foo"));
            HttpHeadersCollection mockHeaders = new(new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Custom-Header", "CustomValue" }
            });
            Uri mockUri = new("https://example.com/foo");
            IEnumerable<ClaimsIdentity> mockIdentities =
            [
                new(
                [
                    new Claim(ClaimTypes.Name, "testUser")
                ])
            ];
            string mockMethod = "GET";

            // Act
            MockHttpRequestData mockHttpRequestData = new(
                functionContext: mockFunctionContext,
                body: mockBody,
                headers: mockHeaders,
                cookies: null,
                url: mockUri,
                identities: mockIdentities,
                method: mockMethod
            );

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mockHttpRequestData, Is.Not.Null);
                Assert.That(mockHttpRequestData.Body, Is.EqualTo(mockBody));
                Assert.That(mockHttpRequestData.Headers, Is.EqualTo(mockHeaders));
                Assert.That(mockHttpRequestData.Cookies, Is.Not.Null);
                Assert.That(mockHttpRequestData.Identities, Is.EqualTo(mockIdentities));
                Assert.That(mockHttpRequestData.Method, Is.EqualTo(mockMethod));
                Assert.That(mockHttpRequestData.Url, Is.EqualTo(mockUri));
                Assert.That(mockHttpRequestData.FunctionContext, Is.EqualTo(mockFunctionContext));
            });
        }
    }
}
