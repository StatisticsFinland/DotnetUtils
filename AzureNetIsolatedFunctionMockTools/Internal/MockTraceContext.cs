using Microsoft.Azure.Functions.Worker;

namespace AzureNetIsolatedFunctionMockTools.Internal
{
    internal class MockTraceContext : TraceContext
    {
        public override string TraceParent => throw new NotImplementedException();

        public override string TraceState => throw new NotImplementedException();
    }
}
