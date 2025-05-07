namespace AzureNetIsolatedFunctionMockTools
{
    /// <summary>
    /// Mock implementation of <see cref="IServiceProvider"/> for testing purposes. This class allows you to create a mock service provider that can return services of specified types.
    /// </summary>
    /// <param name="services">Dictionary of services to be provided. The key is the type of the service, and the value is the instance of the service. Default is an empty dictionary.</param>
    public class MockServiceProvider(Dictionary<Type, object>? services = null) : IServiceProvider
    {
        private readonly Dictionary<Type, object> _services = services ?? [];

        public object? GetService(Type serviceType)
        {
            return _services != null && _services.TryGetValue(serviceType, out var service) ? service : null;
        }
    }
}
