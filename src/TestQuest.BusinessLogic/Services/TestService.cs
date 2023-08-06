using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class TestService : ITestService
{
    private readonly ITestRepository _testRepository;

    public TestService(ITestRepository testRepository) 
        => _testRepository = testRepository;

    public async Task<bool> CreateAsync(TestDto model, CancellationToken token = default)
    {
        DbTest dbTest = model.DbResultTestToDto();
        bool createResult = await _testRepository.CreateAsync(dbTest, token);
        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        bool deleteResult = await _testRepository.DeleteAsync(id, token);
        return deleteResult;
    }

    public async Task<TestDto> GetAsync(string id, CancellationToken token = default)
    {
        DbTest dbTest = await _testRepository.GetAsync(id, token);
        TestDto testDto = dbTest.DbTestToDto();
        return testDto;
    }

    public async Task<IEnumerable<TestDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbTest> dbTests = await _testRepository.GetAsync(token);
        IEnumerable<TestDto> testsDtos = dbTests.Select(t => t.DbTestToDto());
        return testsDtos;
    }

    public async Task<bool> UpdateAsync(TestDto model, CancellationToken token = default)
    {
        DbTest dbTest = model.DbResultTestToDto();
        bool updateResult = await _testRepository.UpdateAsync(dbTest, token);
        return updateResult;
    }
}