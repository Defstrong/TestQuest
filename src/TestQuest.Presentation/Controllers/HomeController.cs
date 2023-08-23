using Microsoft.AspNetCore.Mvc;
using TestQuest.BusinessLogic;
namespace TestQuest.Presentation;

public class HomeController : Controller
{
    private readonly ITestService _testService;
    public HomeController(ITestService testRepository)
        => _testService = testRepository;
    public IActionResult Index()
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        
        return View();
    }

    [HttpGet("personalarea")]
    public async Task<IActionResult> PersonalArea(CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        var tests = await _testService.GetAllUserTestAsync(@User.FindFirst("Id").Value);
        return View(tests);
    }

}
