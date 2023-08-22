using Microsoft.AspNetCore.Mvc;
using TestQuest.BusinessLogic;
namespace TestQuest.Presentation;

[Route("user")]
public sealed class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
        => _userService = userService;

    [HttpGet("leaderboard")]
    public async Task<IActionResult> LeaderBoard(CancellationToken token = default)
    {
        var users = await _userService.GetAsync(token);
        var sortUser = users.OrderByDescending(u => u.RatingPoints).ToList();
        return View(sortUser);
    }
}