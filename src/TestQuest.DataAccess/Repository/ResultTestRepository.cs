namespace TestQuest.DataAccess;

public sealed class ResultTestRepository : BaseRepository<DbResultTest>, IResultTestRepository
{
    public ResultTestRepository(TestQuestDbContext db) : base(db) { }
}