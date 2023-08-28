using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public interface IResultTestService : IBaseService<ResultTestDto>
{
    Task<ResultTestDto> ResultTestAsync(string testId, UserDto user, List<string> answers, CancellationToken token = default);
}