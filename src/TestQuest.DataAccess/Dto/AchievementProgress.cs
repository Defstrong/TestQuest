namespace TestQuest.DataAccess;

public sealed record AchievementProgress : BaseDto
{
    public int KnowledgeMaster { get; set; }
    public int AccurateShooter { get; set; }
    public int TestVeteran { get; set; }
    public int Confident { get; set; }
    public int InvincibleQuestionnaire { get; set; }
}