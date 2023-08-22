using Microsoft.AspNetCore.Mvc;
using TestQuest.BusinessLogic;
using TestQuest.DataAccess;
namespace TestQuest.Presentation;

[Route("/test")]
public sealed class TestController : Controller
{
    private readonly ITestService _testService;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    public TestController(ITestService testService, IUserService userService, IUserRepository userRepository)
    {
        ArgumentNullException.ThrowIfNull(testService);
        _testService = testService;
        _userService = userService;
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Create() 
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        
        return View();
    }

    [HttpPost]
    public async Task<bool> CreateTest(TestDto testDto, CancellationToken token = default)
    {
        testDto.AuthorId = User.FindFirst("Id").Value;
        var createResult = await _testService.CreateAsync(testDto, token);
        return createResult;
    }

    [HttpGet("tests")]
    public async Task<IActionResult> Tests(CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        var tests = await _testService.GetWithoutUserTestAsync(User.FindFirst("Id").Value, token);
        return View(tests);
    }

    [HttpGet("mytests")]
    public async Task<IActionResult> MyTests(CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        var tests = await _testService.GetAllUserTestAsync(User.FindFirst("Id").Value, token);
        return View(tests);
    }

    [HttpGet("passing")]
    public async Task<IActionResult> PassingTest(CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        var tests = await _testService.GetAsync(token);
        return View(tests);
    }

    [HttpGet("test/{id}")]
    public async Task<IActionResult> Test([FromRoute]string id, CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        var test = await _testService.GetAsync(id, token);
        return View(test);
    }

    [HttpPost("result/{id}")]
    public async Task<bool> Result([FromRoute]string id, List<string> answers, CancellationToken token = default)
    {
        var user = await _userService.GetAsync(User.FindFirst("Id").Value);
        await _testService.ResultTestAsync(id, user, answers, token);
        var updateResult = await _userService.UpdateAsync(user);

        // if(points is null)
            // RedirectToMyAccount
        return updateResult;
    }
}
