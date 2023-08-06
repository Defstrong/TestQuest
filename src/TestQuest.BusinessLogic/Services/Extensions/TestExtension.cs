using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public static class TestExtension
{
    public static TestDto DbTestToDto(this DbTest dbTest)
        => new()
        {
            Id = dbTest.Id,
            Name = dbTest.Name,
            Difficulty = dbTest.Difficulty,
            TimeLimit = dbTest.TimeLimit,
            TotalQuestions = dbTest.TotalQuestions,
            AuthorId = dbTest.AuthorId,
            CreatedAt = dbTest.CreatedAt,
            Status = dbTest.Status,
            Category = dbTest.Category,
            Questions = dbTest.Questions
        };

    public static DbTest DbResultTestToDto(this TestDto dbTest)
        => new()
        {
            Id = dbTest.Id,
            Name = dbTest.Name,
            Difficulty = dbTest.Difficulty,
            TimeLimit = dbTest.TimeLimit,
            TotalQuestions = dbTest.TotalQuestions,
            AuthorId = dbTest.AuthorId,
            CreatedAt = dbTest.CreatedAt,
            Status = dbTest.Status,
            Category = dbTest.Category,
            Questions = dbTest.Questions
        };
}