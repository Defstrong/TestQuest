using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestQuest.BusinessLogic;
using TestQuest.DataAccess;
namespace TestQuest.Presentation;

[Route("/question")]
public sealed class QuestionController : Controller
{
    private readonly ITestService _testService;
    private readonly IMapper _mapper;
    public QuestionController(ITestService testService, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(testService);
        _testService = testService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<bool> Create(TestDto testDto, CancellationToken token = default)
    {
        foreach(var ii in testDto.Questions)
            foreach(var jj in testDto.Questions.SelectMany(q => q.Options))
            {
                jj.QuestionId = ii.Id;
                Console.WriteLine(jj);
            }

        var createResult = await _testService.CreateAsync(testDto, token);
        return createResult;
    }
}
