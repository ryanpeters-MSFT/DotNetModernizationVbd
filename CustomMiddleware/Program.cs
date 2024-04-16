var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// option 1: use middleware class
app.UseMiddleware<FormatRequestKeyMiddleware>();
app.UseMiddleware<ForbidTestApiKeysMiddleware>();

// option 2: use .Use(...)
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Append("hello", "I'm from the middleware");

        return Task.CompletedTask;
    });

    await next(context);
});

app.MapControllers();

app.Run();
