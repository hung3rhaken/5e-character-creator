using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Main;

public class Character
{
    public string Name { get; set; } = string.Empty;
    public string CharacterClass { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public int Level { get; set; }
    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Intelligence { get; set; }
    public Ability Wisdom { get; set; }
    public Ability Charisma { get; set; }

    public Character()
    {
        Name = "New Guy";
        CharacterClass = "";
        Species = "Human";
        Level = 1;
        Strength = new Ability("Strength", 10);
        Dexterity = new Ability("Dexterity", 10);
        Constitution = new Ability("Constitution", 10);
        Intelligence = new Ability("Intelligence", 10);
        Wisdom = new Ability("Wisdom", 10);
        Charisma = new Ability("Charisma", 10);
    }

    // This property is used to access class-specific functionality.
    [JsonIgnore]
    public ICharacterClass ClassImplementation => CharacterClassFactory.GetAvailableClass(CharacterClass);
}
