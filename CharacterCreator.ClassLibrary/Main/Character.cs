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

    public string FullTitle => $"{Name} the Great";
}
