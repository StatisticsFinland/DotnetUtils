using Microsoft.Azure.Functions.Worker;

namespace AzureNetIsolatedFunctionMockTools.Internal
{
    internal class MockBindingContext : BindingContext
    {
        public override IReadOnlyDictionary<string, object?> BindingData => throw new NotImplementedException();
    }
}
