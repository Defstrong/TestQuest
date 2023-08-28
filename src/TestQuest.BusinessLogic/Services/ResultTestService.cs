using AutoMapper;
using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class ResultTestService : IResultTestService
{
    private readonly IResultTestRepository _resultTestRepository;
    private readonly ITestService _testService;
    private readonly IMapper _mapper;

    public ResultTestService(IResultTestRepository resultTestRepository, IMapper mapper, ITestService testService)
    {
        ArgumentNullException.ThrowIfNull(resultTestRepository);
        ArgumentNullException.ThrowIfNull(mapper);
        ArgumentNullException.ThrowIfNull(testService);

        _resultTestRepository = resultTestRepository;
        _testService = testService;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(ResultTestDto entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        DbResultTest dbResultTest = _mapper.Map<DbResultTest>(entity);
        bool createResult = await _resultTestRepository.CreateAsync(dbResultTest, token);
        
        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        bool deleteResult = await _resultTestRepository.DeleteAsync(id, token);

        return deleteResult;
    }

    public async Task<ResultTestDto> GetAsync(string id, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        DbResultTest? dbResultTest = await _resultTestRepository.GetAsync(id, token);
        ResultTestDto resultTestDto = _mapper.Map<ResultTestDto>(dbResultTest);
        
        return resultTestDto;
    }

    public async Task<IEnumerable<ResultTestDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbResultTest> dbResultTests = await _resultTestRepository.GetAsync(token);
        IEnumerable<ResultTestDto> resultTestDtos = _mapper.Map<IEnumerable<ResultTestDto>>(dbResultTests);

        return resultTestDtos;
    }

    public async Task<bool> UpdateAsync(ResultTestDto entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);
        DbResultTest dbResultTest = _mapper.Map<DbResultTest>(entity);
        bool updateResult = await _resultTestRepository.UpdateAsync(dbResultTest, token);
        return updateResult;
    }

    public async Task<ResultTestDto> ResultTestAsync(string testId, UserDto user, List<string> answers, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(answers);
        ArgumentNullException.ThrowIfNull(user);
        ArgumentException.ThrowIfNullOrEmpty(testId);
        
        byte correctedAnswers = 0;
        var test = await _testService.GetAsync(testId, token);
        
        var anothertest = test.Questions.SelectMany(q =>q.Options);


        var questions = test.Questions.ToList();
        List<QuestionAnswerDto> questionAnswers = new();
        for(int i = 0; i < answers.Count(); i++)
        {
            questionAnswers.Add(new(){
                QuestionText = questions[i].Question,
                CorrectAnswer = questions[i].Answer,
                Answer = answers[i],
                Status = questions[i].Answer == answers[i] ? QuestionStatus.Correct : QuestionStatus.Wrong
            });

            if(questions[i].Answer == answers[i])
                correctedAnswers++;
        }
        var points = correctedAnswers * ((int)test.Difficulty + 1);
        user.RatingPoints += points;
        AchievementResult(user, correctedAnswers, questions.Count(), test.Difficulty);

        ResultTestDto resultTest = new() {
            UserId = user.Id,
            TestId = test.Id,
            CorrectAnswers = correctedAnswers,
            ResultPoints = points,
            CompletedAt = DateTime.Now,
            QuestionAnswers = _mapper.Map<List<DbQuestionAnswer>>(questionAnswers)
        };

        await _testService.SaveResultAsync(resultTest, token);
        return resultTest;
    }

    private void AchievementResult(UserDto user, int correctAnswers, int countQuestion, Difficulty difficulty)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(correctAnswers);
        ArgumentNullException.ThrowIfNull(countQuestion);

        if(correctAnswers == countQuestion && difficulty == Difficulty.Impissible 
            && user.Achievements.Contains(Achievement.TestExtender))
                user.Achievements.Add(Achievement.TestExtender);

        if(user.RatingPoints >= 100 && user.Achievements.Contains(Achievement.Connoisseur))
            user.Achievements.Add(Achievement.Connoisseur);

        if(user.RatingPoints >= 1000 && user.Achievements.Contains(Achievement.KnowledgeMaster))
            user.Achievements.Add(Achievement.KnowledgeMaster);

        if(user.RatingPoints >= 10000 && user.Achievements.Contains(Achievement.Guru))
            user.Achievements.Add(Achievement.Guru);

        if(user.RatingPoints >= 5000 && user.Achievements.Contains(Achievement.RapidLearner))
            user.Achievements.Add(Achievement.RapidLearner);
    }
}