using Microsoft.Azure.Functions.Worker;
using System.Collections.Immutable;

namespace AzureNetIsolatedFunctionMockTools.Internal
{
    internal class MockFunctionDefinition : FunctionDefinition
    {
        public override ImmutableArray<FunctionParameter> Parameters => throw new NotImplementedException();

        public override string PathToAssembly => throw new NotImplementedException();

        public override string EntryPoint => throw new NotImplementedException();

        public override string Id => throw new NotImplementedException();

        public override string Name => throw new NotImplementedException();

        public override IImmutableDictionary<string, BindingMetadata> InputBindings => throw new NotImplementedException();

        public override IImmutableDictionary<string, BindingMetadata> OutputBindings => throw new NotImplementedException();
    }
}
