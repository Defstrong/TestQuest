namespace TestQuest.DataAccess;

public sealed record OptionDto : BaseDto
{
    private readonly string? _option;

    public string Option
    {
        get => _option ?? string.Empty;
        init => _option = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public List<QuestionDto> Question { get; set; }
    
}