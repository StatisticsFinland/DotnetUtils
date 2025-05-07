using Microsoft.Azure.Functions.Worker;

namespace AzureNetIsolatedFunctionMockTools.Internal
{
    internal class MockRetryContext : RetryContext
    {
        public override int RetryCount => throw new NotImplementedException();

        public override int MaxRetryCount => throw new NotImplementedException();
    }
}
