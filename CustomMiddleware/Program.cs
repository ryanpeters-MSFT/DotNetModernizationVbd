var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

//app.UseMiddleware<AnotherMiddleware>();
app.UseMiddleware<FormatRequestKeyMiddleware>();
app.UseMiddleware<ForbidTestApiKeysMiddleware>();

app.MapControllers();

app.Run();
