using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Cookie.Services;

namespace Cookie.Controllers;

[AllowAnonymous]
public class LoginController(IUserService userService) : Controller
{
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    [ActionName(nameof(Login))]
    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> LoginPost([Required] string username, [Required] string password, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            if (userService.Authenticate(username, password))
            {
                var claims = userService.GetClaims(username);

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return Redirect(returnUrl);
            }

            ModelState.AddModelError("", "Invalid login");
        }

        return View();
    }

    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return Redirect("/");
    }
}