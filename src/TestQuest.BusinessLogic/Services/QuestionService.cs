using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository) 
        => _questionRepository = questionRepository;

    public async Task<bool> CreateAsync(QuestionDto model, CancellationToken token = default)
    {
        DbQuestion dbQuestion = model.DtoToDbQuestion();
        bool createResult = await _questionRepository.CreateAsync(dbQuestion, token);
        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        bool deleteResult = await _questionRepository.DeleteAsync(id, token);
        return deleteResult;
    }

    public async Task<QuestionDto> GetAsync(string id, CancellationToken token = default)
    {
        DbQuestion dbQuestion = await _questionRepository.GetAsync(id, token);
        QuestionDto questionDto = dbQuestion.DbQuestionToDto();
        return questionDto;
    }

    public async Task<IEnumerable<QuestionDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbQuestion> dbQuestions = await _questionRepository.GetAsync(token);
        IEnumerable<QuestionDto> questionsDtos = dbQuestions.Select(q => q.DbQuestionToDto());
        return questionsDtos;
    }

    public async Task<bool> UpdateAsync(QuestionDto model, CancellationToken token = default)
    {
        DbQuestion dbQuestion = model.DtoToDbQuestion();
        bool updateResult = await _questionRepository.UpdateAsync(dbQuestion, token);
        return updateResult;
    }
}