using Microsoft.Azure.Functions.Worker;
using System.Collections;

namespace AzureNetIsolatedFunctionMockTools.Internal
{
    internal class MockInvocationFeatures : IInvocationFeatures
    {
        public T? Get<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Set<T>(T instance)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
