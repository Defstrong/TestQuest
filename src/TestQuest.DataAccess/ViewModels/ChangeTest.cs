using TestQuest.DataAccess;
namespace TestQuest.Presentation;

public sealed record ChangeTest
{
    public List<string> Question { get; set; }
    public List<string> Answer { get; set; }
    public string Description { get; set; }
    public List<OptionDto> Options { get; set; }
    public int TimeLimit { get; set; }
    public int AgeLimit { get; set; }

}