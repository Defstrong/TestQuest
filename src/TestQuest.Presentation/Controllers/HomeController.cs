using Microsoft.AspNetCore.Mvc;
namespace TestQuest.Presentation.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        Console.WriteLine(User.Identity.IsAuthenticated);
        return View();
    }
}
