namespace CharacterCreator.ClassLibrary.Main;

public class Ability
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int Modifier { get => CalculateModifier(Score); }

    public Ability(string name, int score)
    {
        Name = name;
        Score = score;
    }

    private int CalculateModifier(int score)
    {
        return (int)Math.Floor((score - 10) / 2.0);
    }
}