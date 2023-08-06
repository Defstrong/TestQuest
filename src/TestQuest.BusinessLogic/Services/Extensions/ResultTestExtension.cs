using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public static class ResultTestExtension
{
    public static ResultTestDto DbResultTestToDto(this DbResultTest dbResultTest)
        => new()
        {
            Id = dbResultTest.Id,
            UserId = dbResultTest.UserId,
            CorrectAnswers = dbResultTest.CorrectAnswers,
            Result = dbResultTest.Result,
            CompletedAt = dbResultTest.CompletedAt
        };

    public static DbResultTest DtoToDbResultTest(this ResultTestDto resultTestDto)
        => new()
        {
            Id = resultTestDto.Id,
            UserId = resultTestDto.UserId,
            CorrectAnswers = resultTestDto.CorrectAnswers,
            Result = resultTestDto.Result,
            CompletedAt = resultTestDto.CompletedAt
        };
}