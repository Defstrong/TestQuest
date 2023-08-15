using AutoMapper;
using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(QuestionDto model, CancellationToken token = default)
    {
        DbQuestion dbQuestion = _mapper.Map<DbQuestion>(model);
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
        QuestionDto questionDto = _mapper.Map<QuestionDto>(dbQuestion);
        return questionDto;
    }

    public async Task<IEnumerable<QuestionDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbQuestion> dbQuestions = await _questionRepository.GetAsync(token);
        IEnumerable<QuestionDto> questionsDtos = _mapper.Map<IEnumerable<QuestionDto>>(dbQuestions);
        return questionsDtos;
    }

    public async Task<bool> UpdateAsync(QuestionDto model, CancellationToken token = default)
    {
        DbQuestion dbQuestion = _mapper.Map<DbQuestion>(model);
        bool updateResult = await _questionRepository.UpdateAsync(dbQuestion, token);
        return updateResult;
    }
}