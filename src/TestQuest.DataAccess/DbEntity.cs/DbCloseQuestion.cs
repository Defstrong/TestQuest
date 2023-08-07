namespace TestQuest.DataAccess;

public record DbCloseQuestion : IQuestion
{
    public List<string> Options { get; init; } = new();
}