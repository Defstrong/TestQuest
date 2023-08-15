using Microsoft.AspNetCore.Mvc;
using TestQuest.DataAccess;
using TestQuest.BusinessLogic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace TestQuest.Presentation;

[Route("authorize")]
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
        => _userService = userService;

    [HttpGet("/registration")]
    public IActionResult Registration() => View();

    [HttpPost("/registration")]
    public Task<bool> Registration(UserDto user, CancellationToken token = default)
    {
        HttpContext.Response.Cookies.Append("email", user.Email);
        HttpContext.Response.Cookies.Append("password", user.Password);
        return _userService.CreateAsync(user, token);
    }

    [HttpGet]
    public IActionResult SignIn() => View();

    [HttpPost]
    public async Task<IActionResult> SignIn(SingInData singInData)
    {
        ArgumentNullException.ThrowIfNull(singInData);
        var userDefinition = await _userService.UserDefinition(singInData);

        if(userDefinition is not null)
        {
            var claims = new List<Claim> { 
                new (ClaimsIdentity.DefaultNameClaimType, userDefinition.Email)};

            var id = new ClaimsIdentity(claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));

            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpGet("/signout")]
    public async Task<RedirectResult> SignOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }
}
