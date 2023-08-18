using TestQuest.DataAccess;
using AutoMapper;

namespace TestQuest.BusinessLogic;

public sealed class ResultTestService : IResultTestService
{
    private readonly IResultTestRepository _resultTestRepository;
    private readonly IMapper _mapper;

    public ResultTestService(IResultTestRepository resultTestRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(resultTestRepository);
        _resultTestRepository = resultTestRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(ResultTestDto entity, CancellationToken token = default)
    {
        DbResultTest dbResultTest = _mapper.Map<DbResultTest>(entity);
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
        DbResultTest dbResultTest = _mapper.Map<DbResultTest>(entity);
        bool updateResult = await _resultTestRepository.UpdateAsync(dbResultTest, token);
        return updateResult;
    }
}