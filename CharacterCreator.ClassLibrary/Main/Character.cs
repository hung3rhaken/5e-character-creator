using CharacterCreator.ClassLibrary.Main.CharacterClasses;

namespace CharacterCreator.ClassLibrary.Main;

public class Character
{
    public string Name { get; set; }
    public CharacterClass CharacterClass { get; set; }
    // Multiclassing somewhere here
    public string Species { get; set; }
    public int Level { get; set; }
    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Intelligence { get; set; }
    public Ability Wisdom { get; set; }
    public Ability Charisma { get; set; }

    /// <summary>
    /// Default Character is created as a level 1 Fighter
    /// </summary>
    public Character() : this(new Fighter())
    {
    }

    public Character(CharacterClass characterClass)
    {
        CharacterClass = characterClass;
        Name = "New Guy";
        Species = "Human";
        Level = 1;

        CalculateCharacterValues();
    }

    public void CalculateCharacterValues()
    {
        CharacterClass?.ApplyDefaultAbilityValues(this);
        CharacterClass?.ApplyClassBenefits(this);
    }
}
