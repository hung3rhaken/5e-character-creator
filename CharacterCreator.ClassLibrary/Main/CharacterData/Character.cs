using CharacterCreator.ClassLibrary.Main.CharacterClasses;

namespace CharacterCreator.ClassLibrary.Main.CharacterData;

public class Character
{
    // Base Properties
    public string Name { get; set; }
    public int Level { get; set; }
    public CharacterClass CharacterClass { get; set; }
    public string SubClass { get; set; }
    // Multiclassing somewhere here

    // Origin
    public string Background { get; set; }
    public string Species { get; set; }
    public string Alignment { get; set; }
    public string Size { get; set; }
    public int Speed { get; set; }

    // Dynamic Data
    public int ProficiencyBonus { get; set; }
    public int ArmorClass { get; set; }
    public int MaxHitPoints { get; set; }
    public int CurrentHitPoints { get; set; }
    public string HitDice { get; set; }
    public int MaxHitDice { get; set; } //Todo: HitDice and Max can be consolidated into singular Dict. etc.
    public int Initiative { get; set; }
    public int PassivePerception { get; set; }


    // Abilities
    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Intelligence { get; set; }
    public Ability Wisdom { get; set; }
    public Ability Charisma { get; set; }

    // Saving Throws

    // Skills

    // Feats?

    // Equipment

    // Spellcasting

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

        CalculateInitialCharacterValues();
    }

    public void CalculateCharacterValues()
    {
        CharacterClass?.ApplyDefaultAbilityValues(this);
        CharacterClass?.ApplyClassBenefits(this);
    }

    private void CalculateInitialCharacterValues()
    {
        CharacterClass.ApplyDefaultAbilityValues(this);
        CharacterClass.ApplyClassBenefits(this);
    }
}
