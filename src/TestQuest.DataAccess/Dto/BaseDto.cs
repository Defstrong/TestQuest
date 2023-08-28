namespace TestQuest.DataAccess;

public abstract record BaseDto
{
    public BaseDto()
        => Id = Guid.NewGuid().ToString();

    public string Id { get; set; }
}