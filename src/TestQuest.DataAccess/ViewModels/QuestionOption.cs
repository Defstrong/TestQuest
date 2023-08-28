namespace TestQuest.DataAccess;

public sealed record QuestionOption
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public List<string> Options { get; set; }
}