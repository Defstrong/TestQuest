using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class UserRepository : BaseRepository<DbUser>, IUserRepository
{
    private readonly TestQuestDbContext _db;
    public UserRepository(TestQuestDbContext db) : base(db) 
        => _db = db;
    
    public Task<DbUser?> GetAsync(string email, string password, CancellationToken token = default)
    {
        var userDefinition = _db.Users
            .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
        
        return userDefinition; 
    }
}