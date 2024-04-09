public class ForbidTestApiKeysMiddleware(RequestDelegate next, IConfiguration configuration)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var forbidTestApiKeys = Convert.ToBoolean(configuration["ForbidTestApiKeys"]);

        if (forbidTestApiKeys)
        {
            var apiKey = context.Request.Headers["api-key"].ToString();

            if (apiKey.StartsWith("abcd", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.Headers.Append("Reason", "Test API keys are not allowed");
            }

            return;
        }

        await next(context);
    }
}