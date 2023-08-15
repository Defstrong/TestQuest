namespace TestQuest.DataAccess;

public sealed class QuestionRepository : BaseRepository<DbQuestion>, IQuestionRepository
{
    public QuestionRepository(TestQuestDbContext db) : base(db) { }
}