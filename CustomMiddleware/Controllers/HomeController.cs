using Microsoft.AspNetCore.Mvc;

namespace CustomMiddleware.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    [Route("auth")]
    public IActionResult Authenticate()
    {
        var apiKey = Request.Headers["api-key"];

        return Ok(apiKey);
    }
}
