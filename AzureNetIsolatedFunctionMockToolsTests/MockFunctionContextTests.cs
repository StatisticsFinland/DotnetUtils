using AzureNetIsolatedFunctionMockTools;

namespace AzureNetIsolatedFunctionMockToolsTests
{
    internal class MockFunctionContextTests
    {
        [Test]
        public void MockFunctionContext_DefaultConstructorWithoutParameters_ReturnsDefaultFunctionContextObject()
        {
            // Arrange & Act
            MockFunctionContext mockFunctionContext = new ();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mockFunctionContext.InvocationId, Is.Empty);
                Assert.That(mockFunctionContext.FunctionId, Is.Empty);
                Assert.That(mockFunctionContext.TraceContext, Is.Not.Null);
                Assert.That(mockFunctionContext.BindingContext, Is.Not.Null);
                Assert.That(mockFunctionContext.RetryContext, Is.Not.Null);
                Assert.That(mockFunctionContext.InstanceServices, Is.Not.Null);
                Assert.That(mockFunctionContext.FunctionDefinition, Is.Not.Null);
                Assert.That(mockFunctionContext.Items, Is.Not.Null);
                Assert.That(mockFunctionContext.Features, Is.Not.Null);
            });
        }

        [Test]
        public void MockFunctionContext_DefaultConstructorWithCustomParameters_ReturnsFunctionContextObject()
        {
            // Arrange & Act
            MockFunctionContext mockFunctionContext = new (
                "foo", 
                "bar",
                items: new Dictionary<object, object>()
                {
                    { "baz", "qux" }
                }
            );

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mockFunctionContext.InvocationId, Is.EqualTo("foo"));
                Assert.That(mockFunctionContext.FunctionId, Is.EqualTo("bar"));
                Assert.That(mockFunctionContext.Items, Is.Not.Null);
                Assert.That(mockFunctionContext.Items, Has.Count.EqualTo(1));
                Assert.That(mockFunctionContext.Items.ContainsKey("baz"));
                Assert.That(mockFunctionContext.Items["baz"], Is.EqualTo("qux"));
            });

        }
    }
}