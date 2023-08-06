using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class QuestionRepository : IQuestionRepository
{
    private readonly TestQuestDbContext _db;

    public QuestionRepository(TestQuestDbContext db) => _db = db;

    public async Task<bool> CreateAsync(DbQuestion model, CancellationToken token = default)
    {
        await _db.Questions.AddAsync(model, token);
        int createResult = await _db.SaveChangesAsync(token);
        return createResult > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        DbQuestion question = await _db.Questions.SingleAsync(q => q.Id == id, token);
        _db.Remove(question);
        int deleteResult= await _db.SaveChangesAsync(token);
        return deleteResult > 0;
    }

    public async Task<DbQuestion> GetAsync(string id, CancellationToken token = default)
    {
        DbQuestion question = await _db.Questions.SingleAsync(q => q.Id == id, token);
        return question;
    }

    public async Task<IEnumerable<DbQuestion>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbQuestion> questions = await _db.Questions.ToListAsync(token);
        return questions;
    }

    public async Task<bool> UpdateAsync(DbQuestion model, CancellationToken token = default)
    {
        _db.Entry(model).State = EntityState.Modified;
        int updateResult = await _db.SaveChangesAsync(token);
        return updateResult > 0;
    }
}