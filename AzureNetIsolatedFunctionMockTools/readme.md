# Azure .NET Isolated Function Mock Tools

A library providing mock implementations for Azure .NET Isolated Functions, designed to simplify unit testing by reducing the bootstrapping required to mock Azure Functions infrastructure.

## Overview

This library provides ready-to-use mock implementations of abstract classes and interfaces commonly used in Azure .NET Isolated Functions. Instead of manually creating test doubles or writing complex setup code, you can use these mock implementations to focus on testing your business logic.
The mock implementations are designed to be as un-opinionated as possible, allowing you to override only the properties and methods you need for your tests. All constructor parameters are optional and have sensible defaults, making it easy to create instances with minimal configuration.

## Installation

```bash
dotnet add package AzureNetIsolatedFunctionMockTools
```

## Available Mock Implementations

### MockFunctionContext

Mock implementation of `FunctionContext` for testing purposes.

**Constructor Parameters** (all optional):
- `invocationId` - Unique identifier for the function invocation (default: empty string)
- `functionId` - Unique identifier for the function (default: empty string)
- `traceContext` - TraceContext object (default: new MockTraceContext)
- `bindingContext` - BindingContext object (default: new MockBindingContext)
- `retryContext` - RetryContext object (default: new MockRetryContext)
- `instanceServices` - IServiceProvider object (default: new MockServiceProvider)
- `functionDefinition` - FunctionDefinition object (default: new MockFunctionDefinition)
- `items` - IDictionary<object, object> for storing items (default: new Dictionary)
- `features` - IInvocationFeatures object (default: new MockInvocationFeatures)

**Usage:**
```csharp
MockFunctionContext context = new(
    invocationId: "test-invocation-123",
    functionId: "MyFunction"
);
```

### MockHttpRequestData

Mock implementation of `HttpRequestData` for testing HTTP-triggered functions.

**Constructor Parameters:**
- `functionContext` - **Required** FunctionContext object (recommended: MockFunctionContext)
- `body` - Request body stream (default: new MemoryStream)
- `headers` - HTTP headers collection (default: empty collection)
- `cookies` - HTTP cookies collection (default: empty collection)
- `url` - Request URL (default: https://example.com)
- `identities` - ClaimsIdentity collection (default: empty collection)
- `method` - HTTP method string (default: empty string)
- `response` - HttpResponseData object (default: new MockHttpResponseData)

**Usage:**
```csharp
MockFunctionContext context = new();
MockHttpRequestData request = new(
    functionContext: context,
    method: "POST",
    url: new Uri("https://example.com/api/test"),
    body: new MemoryStream(Encoding.UTF8.GetBytes("{\"test\": \"data\"}"))
);
```

### MockHttpResponseData

Mock implementation of `HttpResponseData` for testing HTTP responses.

**Constructor Parameters:**
- `functionContext` - **Required** FunctionContext object (recommended: MockFunctionContext)
- `statusCode` - HTTP status code (default: HttpStatusCode.OK)
- `headers` - HTTP headers collection (default: empty collection)
- `stream` - Response body stream (default: new MemoryStream)
- `cookies` - HTTP cookies collection (default: empty collection)

**Usage:**
```csharp
MockFunctionContext context = new();
MockHttpResponseData response = new(
    functionContext: context,
    statusCode: HttpStatusCode.Created
);

// Write to response body
response.Body.Write(Encoding.UTF8.GetBytes("Response content"));
```

### MockServiceProvider

Mock implementation of `IServiceProvider` for dependency injection testing.

**Constructor Parameters:**
- `services` - Dictionary<Type, object> of services (default: empty dictionary)

**Usage:**
```csharp
Dictionary<Type, object> services = new()
{
    { typeof(IMyService), new MyServiceMock() },
    { typeof(IConfiguration), configurationMock }
};

MockServiceProvider serviceProvider = new(services);
MockFunctionContext context = new(instanceServices: serviceProvider);
```

## Requirements

- .NET 10.0 or later
- Microsoft.Azure.Functions.Worker package