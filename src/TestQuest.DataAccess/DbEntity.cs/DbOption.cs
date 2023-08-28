namespace TestQuest.DataAccess;

public record DbOption : BaseDbEntity
{
    private readonly string? _option;

    public DbOption()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Option
    {
        get => _option ?? string.Empty;
        init => _option = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string QuestionId { get; set; }
    public virtual DbQuestion Question { get; set; } = new();
}