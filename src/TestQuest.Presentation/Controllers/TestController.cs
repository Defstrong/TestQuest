using Microsoft.AspNetCore.Mvc;
using TestQuest.BusinessLogic;
using TestQuest.DataAccess;
namespace TestQuest.Presentation;

[Route("/test")]
public sealed class TestController : Controller
{
    private readonly ITestService _testService;
    private readonly IUserService _userService;
    private readonly IResultTestService _resultTestService;
    public TestController(ITestService testService, IUserService userService, IResultTestService resultTestService)
    {
        ArgumentNullException.ThrowIfNull(testService);
        ArgumentNullException.ThrowIfNull(userService);
        ArgumentNullException.ThrowIfNull(resultTestService);

        _testService = testService;
        _userService = userService;
        _resultTestService = resultTestService;
    }

    [HttpGet]
    public IActionResult Create() 
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        
        return View();
    }

    [HttpGet("delete/{id}")]
    public Task<bool> Delete([FromRoute] string id, CancellationToken token = default)
    {
        var deleteResult = _testService.DeleteAsync(id, token);

        return deleteResult;
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
    public async Task<IActionResult> Result([FromRoute]string id, List<string> answers, CancellationToken token = default)
    {
        var user = await _userService.GetAsync(User.FindFirst("Id").Value);
        var resulteTest = await _resultTestService.ResultTestAsync(id, user, answers, token);

        await _userService.UpdateAsync(user);

        return View(resulteTest);
    }

    [HttpPost("comment/{id}")]
    public async Task<RedirectResult> CommentAndScoreTest([FromRoute]string id, CommentAndTestScoreDto commentAndTestScore, CancellationToken token = default)
    {
        commentAndTestScore.TestId = id;
        commentAndTestScore.UserId = User.FindFirst("Id").Value;
        var test = await _testService.GetAsync(id, token);
        test.CommentAndTestScores.Add(commentAndTestScore);
        await _testService.UpdateAsync(test);
        return Redirect("/test/tests");
    }


    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateTest([FromRoute]string id, CancellationToken token = default)
    {
        var test = await _testService.GetAsync(id, token);
        Console.WriteLine(test);
        foreach(var ii in test.Questions)
            Console.WriteLine(ii);
        return View(test);
    }

    [HttpPost("update/{id}")]
    public async Task<RedirectResult> UpdateTest(TestDto test, CancellationToken token = default)
    {
        Console.WriteLine(test);
        foreach(var ii in test.Questions)
            Console.WriteLine(ii);

        foreach(var ii in test.Questions.Select(q => q.Options))
            Console.WriteLine(ii);
        await _testService.UpdateAsync(test, token);
        return Redirect("/test/tests");
    }
}
