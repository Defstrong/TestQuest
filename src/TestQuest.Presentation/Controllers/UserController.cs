using Microsoft.AspNetCore.Mvc;
using TestQuest.BusinessLogic;
using TestQuest.DataAccess;
namespace TestQuest.Presentation;

[Route("user")]
public sealed class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly ITestService _testService;
    private readonly IResultTestService _resultTestService;
    public UserController(IUserService userService, ITestService testService, IResultTestService resultTestService)
    {
        _userService = userService;
        _testService = testService;
        _resultTestService = resultTestService;
    }

    [HttpGet("leaderboard")]
    public async Task<IActionResult> LeaderBoard(CancellationToken token = default)
    {
        var users = await _userService.GetAsync(token);
        var sortUser = users.OrderByDescending(u => u.RatingPoints).ToList();
        return View(sortUser);
    }

    [HttpGet("passingtest/{id}")]
    public async Task<IActionResult> PassingTest([FromRoute]string id, CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated)
            return RedirectToAction("Registration", "Login");

        var test = await _testService.GetAsync(id, token);
        return View(test);
    }

    [HttpGet("admin")]
    public async Task<IActionResult> Users(CancellationToken token = default)
    {
        if(!User.Identity.IsAuthenticated) 
            return RedirectToAction("Registration", "Login");
        
        if(User.FindFirst("Role").Value != Role.Admin.ToString())
            return RedirectToAction("Index", "Home");

        var users = await _userService.GetAsync(token);
        return View(users);
    }

    [HttpGet("admin/usertestsscore/{userId}")]
    public async Task<IActionResult> UserTestCommentAndScore([FromRoute]string userId, CancellationToken token = default)
    {
        var userTests = await _testService.GetAllUserTestAsync(userId, token);
        return View(userTests);
    }

    [HttpPost("result/{id}")]
    public async Task<IActionResult> Result([FromRoute]string id, List<string> answers, CancellationToken token = default)
    {
        var user = await _userService.GetAsync(User.FindFirst("Id").Value);
        var resulteTest = await _resultTestService.ResultTestAsync(id, user, answers, token);

        await _userService.UpdateAsync(user);
        return View(resulteTest);
    }
}