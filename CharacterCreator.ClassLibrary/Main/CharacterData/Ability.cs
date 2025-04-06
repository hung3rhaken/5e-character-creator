namespace CharacterCreator.ClassLibrary.Main.CharacterData;

public class Ability
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int Modifier { get => CalculateModifier(Score); }
    public bool HasSavingThrowProficiency { get; set; }

    public Ability()
    {
        
    }

    public Ability(string name, int score)
    {
        Name = name;
        Score = score;
        HasSavingThrowProficiency = false;
    }

    private int CalculateModifier(int score)
    {
        return (int)Math.Floor((score - 10) / 2.0);
    }
}