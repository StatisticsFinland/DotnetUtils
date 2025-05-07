# DotnetUtils
Collection of utilities for .NET applications used and maintained by Statistics Finland.

## Azure .NET Isolated Function Mock Tools

### Overview
This library provides a set of mock implementations for Azure .NET Isolated functions. Implementations are designed to be used in unit tests and developer can choose which fields to mock based on their needs.

### Mock Implementations
Currently the library provides mocking support for the following abstract classes and interfaces:
- `HttpRequestData`
- `HttpResponseData`
- `FunctionContext`
- `IServiceProvider`