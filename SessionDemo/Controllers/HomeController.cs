using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionDemo.Models;

namespace SessionDemo.Controllers;

public class HomeController : Controller
{
    private const string loggedUserKey = "LoggedUser";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        if (context.HttpContext.Session.Keys.Contains(loggedUserKey))
        {
            var loggedUserSerialized = context.HttpContext.Session.GetString(loggedUserKey);
            var loggedUser = JsonSerializer.Deserialize<LoggedUser>(loggedUserSerialized);

            ViewBag.LoggedUser = loggedUser;
        }
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login(string name)
    {
        var client = new LoggedUser
        {
            Id = 1,
            Name = name,
            BirthDate = DateTime.Parse("11/20/1983")
        };

        // sets session cookie only after initial use
        HttpContext.Session.SetString("UserAge", $"{(DateTime.Now.Date - client.BirthDate).TotalDays / 365.25}");

        var currentClient = JsonSerializer.Serialize(client);

        HttpContext.Session.SetString(loggedUserKey, currentClient);

        return View(client);
    }
}
