using Microsoft.AspNetCore.Mvc;
using TestQuest.BusinessLogic;
using TestQuest.DataAccess;
namespace TestQuest.Presentation;

[Route("/test")]
public sealed class TestController : Controller
{
    private readonly ITestService _testService;
    private readonly IResultTestService _resultTestService;
    public TestController(ITestService testService, IUserService userService, IResultTestService resultTestService)
    {
        ArgumentNullException.ThrowIfNull(testService);
        ArgumentNullException.ThrowIfNull(userService);
        ArgumentNullException.ThrowIfNull(resultTestService);

        _testService = testService;
        _resultTestService = resultTestService;
    }

    [HttpGet]
    public IActionResult Create() 
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        
        return View();
    }

    [HttpPost]
    public async Task<RedirectResult> CreateTest(TestDto testDto, CancellationToken token = default)
    {
        testDto.AuthorId = User.FindFirst("Id").Value;
        await _testService.CreateAsync(testDto, token);
        return Redirect("/test/tests");
    }

    [HttpGet("delete/{id}")]
    public async Task<RedirectResult> DeleteTest([FromRoute] string id, CancellationToken token = default)
    {
        await _testService.DeleteAsync(id, token);

        return Redirect("/personalarea");
    }

    [HttpGet("tests")]
    public async Task<IActionResult> Tests(CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");
        var tests = await _testService.GetWithoutUserTestAsync(User.FindFirst("Id").Value, token);
        return View(tests);
    }

    [HttpPost("tests")]
    public async Task<IActionResult> Tests(string searchTestWithName, CancellationToken token = default)
    {
        var tests = await _testService.SearchTestAsync(searchTestWithName, User.FindFirst("Id").Value, token);
        return View(tests);
    }

    [HttpPost("comment/{id}")]
    public async Task<RedirectResult> CommentAndScoreTest([FromRoute]string id, CommentAndTestScoreDto commentAndTestScore, CancellationToken token = default)
    {
        // Console.WriteLine(commentAndTestScore);
        commentAndTestScore.Id = Guid.NewGuid().ToString();
        commentAndTestScore.TestId = id;
        commentAndTestScore.UserId = User.FindFirst("Id").Value;
        commentAndTestScore.UserName = User.FindFirst("UserName").Value;

        var test = await _testService.GetAsync(id, token);
        foreach(var ii in test.Questions.SelectMany(q => q.Options))
            Console.WriteLine(ii);

        test.CommentAndTestScores.Add(commentAndTestScore);
        await _testService.UpdateAsync(test);

        test.Questions.SelectMany(q => q.Options);
        foreach(var ii in test.Questions.SelectMany(q => q.Options))
            Console.WriteLine(ii);

        return Redirect("/test/tests");
    }

    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateTest([FromRoute]string id, CancellationToken token = default)
    {
        var test = await _testService.GetAsync(id, token);
        return View(test);
    }

    [HttpPost("update/{id}")]
    public async Task<RedirectResult> UpdateTest(TestDto test, CancellationToken token = default)
    {
        await _testService.UpdateAsync(test, token);
        return Redirect("/personalarea");
    }
}
