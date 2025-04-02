namespace CharacterCreator.ClassLibrary.Main;

public abstract class CharacterBase
{
    public string Name { get; set; } = string.Empty;
    public string CharacterClassName { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public int Level { get; set; }
    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Intelligence { get; set; }
    public Ability Wisdom { get; set; }
    public Ability Charisma { get; set; }
}
