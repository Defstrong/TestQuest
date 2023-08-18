namespace TestQuest.DataAccess;

public abstract record BaseDbEntity
{
    private readonly string? _id;

    public string Id { get; set; }
}