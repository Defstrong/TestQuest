using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public interface ITestService : IBaseService<TestDto>
{
    Task ResultTestAsync(string testId, UserDto user, List<string> answers, CancellationToken token = default);
    Task<IEnumerable<TestDto>> GetWithoutUserTestAsync(string userId, CancellationToken token = default);
    Task<IEnumerable<TestDto>> GetAllUserTestAsync(string userId, CancellationToken token = default);
}