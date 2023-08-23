namespace TestQuest.DataAccess;

public abstract record BaseDto
{
    private readonly string? _id;
    public BaseDto()
        => Id = Guid.NewGuid().ToString();

    public string Id { get; set; }
}