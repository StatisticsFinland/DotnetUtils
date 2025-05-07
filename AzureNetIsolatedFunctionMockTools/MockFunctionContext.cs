using Microsoft.Azure.Functions.Worker;
using AzureNetIsolatedFunctionMockTools.Internal;

namespace AzureNetIsolatedFunctionMockTools
{
    /// <summary>
    /// Mock implementation of <see cref="FunctionContext"/> for testing purposes. All fields are optional and will be initialized to default values if not provided.
    /// </summary>
    /// <param name="invocationId">The unique identifier for the function invocation. Default is an empty string.</param>
    /// <param name="functionId">The unique identifier for the function. Default is an empty string.</param>
    /// <param name="traceContext"><see cref="TraceContext"/> object. Default is a new <see cref="MockTraceContext"/>.</param>
    /// <param name="bindingContext"><see cref="BindingContext"/> object. Default is a new <see cref="MockBindingContext"/>.</param>
    /// <param name="retryContext"><see cref="RetryContext"/> object. Default is a new <see cref="MockRetryContext"/>.</param>
    /// <param name="instanceServices"><see cref="instanceServices"/> object. Default is a new <see cref="MockServiceProvider"/>.</param>
    /// <param name="functionDefinition"><see cref="FunctionDefinition"/> object. Default is a new <see cref="MockFunctionDefinition"/>.</param>
    /// <param name="items"><see cref="IDictionary{TKey, TValue}"/> object. Default is a new <see cref="Dictionary{TKey, TValue}"/>.</param>
    /// <param name="features"><see cref="IInvocationFeatures"/> object. Default is a new <see cref="MockInvocationFeatures"/>.</param>
    public class MockFunctionContext(
        string? invocationId = null,
        string? functionId = null,
        TraceContext? traceContext = null,
        BindingContext? bindingContext = null,
        RetryContext? retryContext = null,
        IServiceProvider? instanceServices = null,
        FunctionDefinition? functionDefinition = null,
        IDictionary<object, object>? items = null,
        IInvocationFeatures? features = null)
        : FunctionContext
    {
        public override string InvocationId => invocationId ?? string.Empty;

        public override string FunctionId => functionId ?? string.Empty;

        public override TraceContext TraceContext => traceContext ?? new MockTraceContext();

        public override BindingContext BindingContext => bindingContext ?? new MockBindingContext();

        public override RetryContext RetryContext => retryContext ?? new MockRetryContext();

        public override IServiceProvider InstanceServices { get; set; } = instanceServices ?? new MockServiceProvider();

        public override FunctionDefinition FunctionDefinition => functionDefinition ?? new MockFunctionDefinition();

        public override IDictionary<object, object> Items { get; set; } = items ?? new Dictionary<object, object>();

        public override IInvocationFeatures Features => features ?? new MockInvocationFeatures();
    }
}
