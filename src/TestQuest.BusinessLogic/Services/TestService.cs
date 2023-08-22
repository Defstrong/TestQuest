using AutoMapper;
using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class TestService : ITestService
{
    private readonly ITestRepository _testRepository;
    private readonly IMapper _mapper;

    public TestService(ITestRepository testRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(testRepository);
        ArgumentNullException.ThrowIfNull(mapper);

        _testRepository = testRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(TestDto entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        entity.TotalQuestions = (byte)entity.Questions.Count();
        DbTest? dbTest = _mapper.Map<DbTest>(entity);
        bool createResult = await _testRepository.CreateAsync(dbTest, token);

        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        bool deleteResult = await _testRepository.DeleteAsync(id, token);

        return deleteResult;
    }

    public async Task<TestDto> GetAsync(string id, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        DbTest? dbTest = await _testRepository.GetAsync(id, token);
        TestDto testDto = _mapper.Map<TestDto>(dbTest);

        return testDto;
    }

    public async Task<IEnumerable<TestDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbTest> dbTests = await _testRepository.GetAsync(token);
        IEnumerable<TestDto> testsDtos = _mapper.Map<IEnumerable<TestDto>>(dbTests);

        return testsDtos;
    }

    public async Task<IEnumerable<TestDto>> GetWithoutUserTestAsync(string userId, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(userId);

        IEnumerable<DbTest> dbTests = await _testRepository.GetWithoutUserTestAsync(userId, token);
        IEnumerable<TestDto> testsDtos = _mapper.Map<IEnumerable<TestDto>>(dbTests);

        return testsDtos;
    }

    public async Task<IEnumerable<TestDto>> GetAllUserTestAsync(string userId, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(userId);

        IEnumerable<DbTest> dbUserTests = await _testRepository.GetAllUserTestAsync(userId, token);
        IEnumerable<TestDto> userTests = _mapper.Map<IEnumerable<TestDto>>(dbUserTests);

        return userTests;
    }

    public async Task<bool> UpdateAsync(TestDto entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        DbTest dbTest = _mapper.Map<DbTest>(entity);
        bool updateResult = await _testRepository.UpdateAsync(dbTest, token);

        return updateResult;
    }

    public async Task ResultTestAsync(string testId, UserDto user, List<string> answers, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(answers);
        ArgumentNullException.ThrowIfNull(user);
        ArgumentException.ThrowIfNullOrEmpty(testId);
        
        byte correctedAnswers = 0;
        var test = await GetAsync(testId, token);
        var questions = test.Questions.ToList();
        List<QuestionAnswerDto> questionAnswers = new();
        for(int i = 0; i < answers.Count(); i++)
        {
            questionAnswers.Add(new(){
                QuestionText = questions[i].Answer,
                Answer = answers[i],
                Status = questions[i].Answer == answers[i] ? QuestionStatus.Correct : QuestionStatus.Wrong
            });

            if(questions[i].Answer == answers[i])
                correctedAnswers++;
        }

        user.RatingPoints += correctedAnswers * ((int)test.Difficulty + 1);
        AchievementResult(user, correctedAnswers, questions.Count(), test.Difficulty);

        ResultTestDto resultTest = new() {
            UserId = user.Id,
            CorrectAnswers = correctedAnswers,
            ResultPoints = user.RatingPoints,
            CompletedAt = DateTime.Now,
            QuestionAnswers = _mapper.Map<List<DbQuestionAnswer>>(questionAnswers)
        };

        await _testRepository.SaveResultAsync(_mapper.Map<DbResultTest>(resultTest), token);
    }

    private void AchievementResult(UserDto user, int correctAnswers, int countQuestion, Difficulty difficulty)
    {
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
