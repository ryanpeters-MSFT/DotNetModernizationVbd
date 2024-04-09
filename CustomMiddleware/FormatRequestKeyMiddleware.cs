public class FormatRequestKeyMiddleware(RequestDelegate next)
{
    public Task InvokeAsync(HttpContext context)
    {
        // retrieve the api-key header
        var apiKey = context.Request.Headers["api-key"];

        // re-save key as lowercase
        context.Request.Headers["api-key"] = apiKey.ToString().ToLower();

        // Call the next delegate/middleware in the pipeline.
        return next(context);
    }
}