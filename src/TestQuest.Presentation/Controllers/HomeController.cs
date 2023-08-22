using Microsoft.AspNetCore.Mvc;
namespace TestQuest.Presentation.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        
        return View();
    }

    [HttpGet]
    public IActionResult PersonalArea()
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        
        return View();
    }

}
