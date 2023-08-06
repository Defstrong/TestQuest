using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class ResultTestService : IResultTestService
{
    private readonly IResultTestRepository _resultTestRepository;

    public ResultTestService(IResultTestRepository resultTestRepository)
        => _resultTestRepository = resultTestRepository;

    public async Task<bool> CreateAsync(ResultTestDto model, CancellationToken token = default)
    {
        DbResultTest dbResultTest = model.DtoToDbResultTest();
        bool createResult = await _resultTestRepository.CreateAsync(dbResultTest, token);
        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        bool deleteResult = await _resultTestRepository.DeleteAsync(id, token);
        return deleteResult;
    }

    public async Task<ResultTestDto> GetAsync(string id, CancellationToken token = default)
    {
        DbResultTest dbResultTest = await _resultTestRepository.GetAsync(id, token);
        ResultTestDto resultTestDto = dbResultTest.DbResultTestToDto();
        return resultTestDto;
    }

    public async Task<IEnumerable<ResultTestDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbResultTest> dbResultTests = await _resultTestRepository.GetAsync(token);
        IEnumerable<ResultTestDto> resultTestDtos = dbResultTests.Select(rt => rt.DbResultTestToDto());
        return resultTestDtos;
    }

    public async Task<bool> UpdateAsync(ResultTestDto model, CancellationToken token = default)
    {
        DbResultTest dbResultTest = model.DtoToDbResultTest();
        bool updateResult = await _resultTestRepository.UpdateAsync(dbResultTest, token);
        return updateResult;
    }
}