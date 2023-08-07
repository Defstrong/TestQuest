using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestQuest.Presentation.Models;
using TestQuest.DataAccess;
using TestQuest.BusinessLogic;

namespace TestQuest.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IQuestionService _questionService;

    public HomeController(ILogger<HomeController> logger, IQuestionService questionService)
    {
        _questionService = questionService;
        _logger = logger;
    }

    [HttpGet("index")]
    public async Task<bool> Index(QuestionDto questionDto)
    {
        return await _questionService.CreateAsync(questionDto);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
