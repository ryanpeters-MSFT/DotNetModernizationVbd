# Custom Middleware in .NET Core

In modern .NET, HttpModules and HttpHandlers have been replaced with pluggable, custom middleware components. A middleware class is simply an `Invoke` or `InvokeAsync` method and access to the `HttpContext`. As part of the pipeline flow, part of the invocation includes a reference to the "next" middleware after the current one. 

## HttpModules and HttpHandlers Background

In the ASP.NET Framework, HTTP Modules and HTTP Handlers were integral parts of the request processing pipeline

- **HTTP Handlers** were classes that implemented `IHttpHandler` and were used to handle requests with a given file name or extension
- **HTTP Modules** were classes that implemented `IHttpModule` and were invoked for every request. They could short-circuit (stop further processing of) a request, add to the HTTP response, or create their own

However, in .NET Core, these concepts are no longer supported and have been replaced by **Middleware**:

- Middleware is simpler than HTTP modules and handlers
- The roles of both modules and handlers have been taken over by middleware
- Middleware is configured using code rather than in `Web.config`
- Pipeline branching in middleware allows you to send requests to specific middleware, based on not only the URL but also on request headers, query strings, etc
- Middleware is invoked in principle for every request, can short-circuit a request, and can create their own HTTP response
- The order of middleware is based on the order in which they’re inserted into the request pipeline

This transition to middleware provides a more flexible and configurable request processing pipeline, enhancing the capabilities of .NET Core applications

## Invocation

```
curl http://localhost:5282/api/auth -H "api-key: ABCDEFG123"
```

*Note: to run with ForbidTestApiKeys=true, run:*

```
dotnet run ForbidTestApiKeys=true
```