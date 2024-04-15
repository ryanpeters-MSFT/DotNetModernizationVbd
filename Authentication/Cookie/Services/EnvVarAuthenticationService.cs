using System.Security.Claims;

namespace Cookie.Services;

public class EnvVarUserService : IUserService
{
    public bool Authenticate(string username, string password)
    {
        var applicationUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
        var applicationPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");

        return username == applicationUsername && password == applicationPassword;
    }

    public ICollection<Claim> GetClaims(string username)
    {
        // assume I've looked up the user already...

        return
        [
            new Claim(ClaimTypes.Role, "developer"),
            new Claim(ClaimTypes.Email, "ryanpeters@microsoft.com"),
            new Claim("admin", "true")
        ];
    }
}