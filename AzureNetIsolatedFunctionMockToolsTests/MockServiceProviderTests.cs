using AzureNetIsolatedFunctionMockTools;

namespace AzureNetIsolatedFunctionMockToolsTests
{
    internal class MockServiceProviderTests
    {
        [Test]
        public void MockServiceProvider_DefaultConstructorWithoutParameters_ReturnsDefaultServiceProviderObject()
        {
            // Arrange
            Type testType = typeof(string);

            // Act
            MockServiceProvider mockServiceProvider = new();
            object? mockService = mockServiceProvider.GetService(testType);

            Assert.Multiple(() =>
            {
                Assert.That(mockServiceProvider, Is.Not.Null);
                Assert.That(mockService, Is.Null);
            });
        }

        [Test]
        public void MockServiceProvider_DefaultConstructorWithCustomParameters_ReturnsServiceProviderObjectWithServices()
        {
            // Arrange
            Dictionary<Type, object> services = new()
            {
                { typeof(string), "test" },
                { typeof(int), 42 },
                { typeof(bool), "maybe" }
            };

            // Act
            MockServiceProvider mockServiceProvider = new(services);
            object? stringService = mockServiceProvider.GetService(typeof(string));
            object? intService = mockServiceProvider.GetService(typeof(int));
            object? boolService = mockServiceProvider.GetService(typeof(bool));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mockServiceProvider, Is.Not.Null);
                Assert.That(stringService, Is.EqualTo("test"));
                Assert.That(intService, Is.EqualTo(42));
                Assert.That(boolService, Is.EqualTo("maybe"));
            });
        }
    }
}
