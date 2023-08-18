namespace TestQuest.DataAccess;

public sealed record ResultTestDto : BaseDbEntity
{
    private readonly string? _idUser;
    private readonly byte? _correctAnswers;
    private readonly uint? _result;
    private readonly DateTime? _completedAt;

    public string IdUser 
    {
        get => _idUser ?? string.Empty;
        init => _idUser = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public byte CorrectAnswers
    {
        get => _correctAnswers ?? 0;
        init => _correctAnswers = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public uint Result
    {
        get => _result ?? 0;
        init => _result = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public DateTime CompletedAt
    {
        get => _completedAt ?? new DateTime();
        init => _completedAt = value >= DateTime.Now
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}