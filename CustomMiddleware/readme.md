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

## Middleware Processing

The ASP.NET Core request pipeline consists of a sequence of request delegates, called one after the other. The following diagram demonstrates the concept. The thread of execution follows the black arrows.

![middleware](./../.images/request-delegate-pipeline.png)

Each delegate can perform operations before and after the next delegate. Exception-handling delegates should be called early in the pipeline, so they can catch exceptions that occur in later stages of the pipeline.

The simplest possible ASP.NET Core app sets up a single request delegate that handles all requests. This case doesn't include an actual request pipeline. Instead, a single anonymous function is called in response to every HTTP request.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from 2nd delegate.");
});

app.Run();
```

More Information: [Create a middleware pipeline with `WebApplication`](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0#create-a-middleware-pipeline-with-webapplication)

## Running the Example

In this example, the request to the `/api/auth` endpoint will simply return the processed value of the "api-key" header value. 

- The `FormatRequestKeyMiddleware` middleware class will force the API key to be all lowercase
- The `ForbidTestApiKeysMiddleware` middleware class will deny test key values that start with the letters "abcd", unless the configuration value of "ForbidTestApiKeys" is false.

```shell
# run the application
dotnet run

# or, optionally, run with the ForbidTestApiKeys value as "false"
dotnet run ForbidTestApiKeys=false

# use curl to get format the API key
curl http://localhost:5282/api/auth -v -H "api-key: ABCDEFG123"
```