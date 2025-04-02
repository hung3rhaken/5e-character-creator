namespace CharacterCreator.ClassLibrary.Main;

public class Character
{
    public string Name { get; set; } = string.Empty;
    public string CharacterClass { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public int Level { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }


    // Computed properties for ability modifiers
    public int StrengthModifier => CalculateModifier(Strength);
    public int DexterityModifier => CalculateModifier(Dexterity);
    public int ConstitutionModifier => CalculateModifier(Constitution);
    public int IntelligenceModifier => CalculateModifier(Intelligence);
    public int WisdomModifier => CalculateModifier(Wisdom);
    public int CharismaModifier => CalculateModifier(Charisma);

    private int CalculateModifier(int score)
    {
        return (int)Math.Floor((score - 10) / 2.0);
    }
}
