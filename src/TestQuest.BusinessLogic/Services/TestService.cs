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

    public Task<bool> SaveResultAsync(ResultTestDto entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var dbResultTest = _mapper.Map<DbResultTest>(entity);
        var saveResultAsync = _testRepository.SaveResultAsync(dbResultTest, token);

        return saveResultAsync;
    }
}
