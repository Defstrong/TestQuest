namespace TestQuest.DataAccess;

public sealed record OptionDto : BaseDto
{
    public List<string> Option { get; init; } = new();
}