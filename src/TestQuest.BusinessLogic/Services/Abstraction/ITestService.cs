using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public interface ITestService : IBaseService<TestDto>
{
    Task<IEnumerable<TestDto>> GetWithoutUserTestAsync(string userId, CancellationToken token = default);
    Task<IEnumerable<TestDto>> GetAllUserTestAsync(string userId, CancellationToken token = default);
    Task<bool> SaveResultAsync(ResultTestDto dbResultTest, CancellationToken token = default);
}