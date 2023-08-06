using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public static class QuestoinExctensions
{
    public static QuestionDto DbQuestionToDto(this DbQuestion dbQuestion)
        => new()
        {
            Id = dbQuestion.Id,
            Question = dbQuestion.Question,
            Answer = dbQuestion.Answer,
            Options = dbQuestion.Options
        };

    public static DbQuestion DtoToDbQuestion(this QuestionDto questionDto)
        => new()
        {
            Id = questionDto.Id,
            Question = questionDto.Question,
            Answer = questionDto.Answer,
            Options = questionDto.Options
        };
}