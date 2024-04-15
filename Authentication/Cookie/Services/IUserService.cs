using System.Security.Claims;

namespace Cookie.Services;

public interface IUserService
{
    bool Authenticate(string username, string password);
    ICollection<Claim> GetClaims(string username);
}